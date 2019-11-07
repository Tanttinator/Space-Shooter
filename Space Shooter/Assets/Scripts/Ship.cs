using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EntityShip), typeof(HealthShip))]
public class Ship : MonoBehaviour
{
    [Header("Ship stats")]
    new public string name;
    public float maxHealth;
    public float cargoSpace;
    [SerializeField] float weight;

    public Engine engine;
    public Cannon cannon;
    public Shield shield;
    public Plating plating;
    public Generator generator;

    [SerializeField] Activatable[] activatablesList;
    public Activatable[] Activatables
    {
        get
        {
            Activatable[] arr = new Activatable[activatablesList.Length + 1];
            arr[0] = cannon;
            for (int i = 0; i < activatablesList.Length; i++)
                arr[i + 1] = activatablesList[i];
            return arr;
        }
    }

    Activation[] activations;

    public EntityShip entity { get; protected set; }
    public HealthShip health { get; protected set; }
    public Weapons weapons { get; protected set; }

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
            float activatablesWeight = 0;
            foreach(Activatable a in activatablesList)
            {
                if (a != null)
                    activatablesWeight += a.weight;
            }
            return weight + (engine != null ? engine.weight : 3) + (cannon != null ? cannon.weight : 5) + (shield != null ? shield.weight : 5) + (plating != null ? plating.weight : 20) + (generator != null ? generator.weight : 5) + activatablesWeight;
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
        activations = new Activation[Activatables.Length];
    }

    private void LateUpdate()
    {
        foreach (Activation a in activations)
            a?.Update(Time.deltaTime);
    }
}
