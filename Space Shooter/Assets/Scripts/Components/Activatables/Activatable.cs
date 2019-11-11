using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Activatable : Component
{
    public float cooldown = 1f;
    public float energyCost = 10f;
    public float energyPerSecond = 0f;

    public virtual Activation GetActivation(Ship ship)
    {
        return new Activation(ship, cooldown, energyCost, energyPerSecond, () => { });
    }
}

public class Activation
{
    Ship ship;
    float cooldown;
    float energyCost;
    float energyPerSecond;
    Action onActivation;
    Action onActivationDown;
    Action onActivationUp;
    public float cdRemaining = 0f;
    bool active = false;

    public Activation(Ship ship, float cooldown, float energyCost, float energyPerSecond, Action onActivationDown, Action onActivationUp = null, Action onActivation = null)
    {
        this.ship = ship;
        this.cooldown = cooldown;
        this.energyCost = energyCost;
        this.energyPerSecond = energyPerSecond;
        this.onActivation = onActivation;
        this.onActivationDown = onActivationDown;
        this.onActivationUp = onActivationUp;
    }

    public void Activate()
    {
        if (active || ship.energy < energyCost)
            return;
        OnActivationDown();
        OnActivation();
        active = true;
    }

    public void Deactivate()
    {
        if (!active)
            return;
        OnActivationUp();
        active = false;
    }

    void OnActivationDown()
    {
        if (cdRemaining > 0f)
            return;
        ship.ChangeEnergyCapacity(-energyCost);
        onActivationDown?.Invoke();
    }

    void OnActivationUp()
    {
        if (cdRemaining > 0f)
            return;
        onActivationUp?.Invoke();
    }

    void OnActivation()
    {
        if (cdRemaining > 0f)
            return;
        if (ship.energy < energyPerSecond * Time.deltaTime)
            Deactivate();
        ship.ChangeEnergyCapacity(-energyPerSecond * Time.deltaTime);
        onActivation?.Invoke();
        cdRemaining = cooldown;
    }

    public void Update(float dt)
    {
        if (active)
            OnActivation();
        if (cdRemaining > 0)
            cdRemaining -= dt;
    }
}
