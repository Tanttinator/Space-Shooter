using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(EntityShip), typeof(HealthShip))]
public class Ship : MonoBehaviour
{
    [Header("Ship stats")]
    new public string name;
    public float maxHealth;
    public float cargoSpace;
    [SerializeField] float weight;

    [Header("Ship Components")]
    public Component[] components;
    public Engine Engine {
        get
        {
            if(components[0] == null || components[0] is Engine)
            {
                return components[0] as Engine;
            }
            Debug.Log("Wrong component type as Engine!");
            return null;
        }
    }
    public Cannon Cannon
    {
        get
        {
            if (components[1] == null || components[1] is Cannon)
            {
                return components[1] as Cannon;
            }
            Debug.Log("Wrong component type as Cannon!");
            return null;
        }
    }
    public Shield Shields
    {
        get
        {
            if (components[2] == null || components[2] is Shield)
            {
                return components[2] as Shield;
            }
            Debug.Log("Wrong component type as Shield!");
            return null;
        }
    }
    public Plating Plating
    {
        get
        {
            if (components[3] == null || components[3] is Plating)
            {
                return components[3] as Plating;
            }
            Debug.Log("Wrong component type as Plating!");
            return null;
        }
    }
    public Generator Generator
    {
        get
        {
            if (components[4] == null || components[4] is Generator)
            {
                return components[4] as Generator;
            }
            Debug.Log("Wrong component type as Generator!");
            return null;
        }
    }

    public Activatable[] Activatables
    {
        get
        {
            Activatable[] arr = new Activatable[components.Length - 5 + 1];
            arr[0] = Cannon;
            for (int i = 0; i < components.Length - 5; i++)
                arr[i + 1] = components[i + 5] as Activatable;
            return arr;
        }
    }

    Activation[] activations;

    public EntityShip entity { get; protected set; }
    public HealthShip health { get; protected set; }
    public Weapons weapons { get; protected set; }
    public Inventory inventory { get; protected set; }

    float ChargeRate
    {
        get
        {
            return (Generator != null ? Generator.chargeRate : 0f);
        }
    }
    float ChargeStartDelay
    {
        get
        {
            return 5f;
        }
    }
    float MaxEnergy
    {
        get
        {
            return (Generator != null ? Generator.maxCapacity : 0f);
        }
    }
    public float energy { get; protected set; }
    float chargeDelay = 0f;

    public Action<Component, int> onComponentSet;
    public Action<int> onComponentRemoved;
    public Action<float, float> onEnergyChanged;

    public bool HasWeapons
    {
        get
        {
            return weapons != null;
        }
    }
    public float Weight
    {
        get
        {
            float weight = this.weight;
            foreach(Component c in components)
            {
                if (c != null)
                    weight += c.weight;
            }
            return weight;
        }
    }

    public void ChangeEnergyCapacity(float amount)
    {
        if (amount < 0)
            chargeDelay = ChargeStartDelay;

        energy = Mathf.Clamp(energy + amount, 0f, MaxEnergy);
        onEnergyChanged?.Invoke(energy, MaxEnergy);
    }

    public bool SetComponent(Component component, int slot)
    {
        if(CanSetComponent(component, slot))
        {
            if(components[slot] != null)
                inventory.AddItem(components[slot]);
            components[slot] = component;
            onComponentSet(component, slot);
            return true;
        }
        return false;
    }

    public void RemoveComponent(int slot)
    {
        components[slot] = null;
        onComponentRemoved?.Invoke(slot);
    }

    bool CanSetComponent(Component component, int slot)
    {
        bool valid = slot < components.Length && (components[slot] == null || components[slot].weight <= inventory.SpaceLeft());
        switch(slot)
        {
            case 0:
                return valid && component is Engine;
            case 1:
                return valid && component is Cannon;
            case 2:
                return valid && component is Shield;
            case 3:
                return valid && component is Plating;
            case 4:
                return valid && component is Generator;
            default:
                return valid && component is Activatable;
        }
    }

    public void Activate(int index)
    {
        if (index >= activations.Length || index < 0)
            return;

        if (activations[index] == null)
            activations[index] = Activatables[index]?.GetActivation(this);

        activations[index]?.Activate();
    }

    public void Deactivate(int index)
    {
        if (index >= activations.Length || index < 0)
            return;

        if (activations[index] == null)
            activations[index] = Activatables[index]?.GetActivation(this);

        activations[index]?.Deactivate();
    }

    private void Awake()
    {
        entity = GetComponent<EntityShip>();
        health = GetComponent<HealthShip>();
        weapons = GetComponent<Weapons>();
        inventory = GetComponent<Inventory>();
        activations = new Activation[Activatables.Length];
    }

    private void Start()
    {
        ChangeEnergyCapacity(MaxEnergy);
    }

    private void Update()
    {
        if (chargeDelay > 0f)
        {
            chargeDelay -= Time.deltaTime;
        }
        else
        {
            ChangeEnergyCapacity(ChargeRate * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        foreach (Activation a in activations)
            a?.Update(Time.deltaTime);
    }
}
