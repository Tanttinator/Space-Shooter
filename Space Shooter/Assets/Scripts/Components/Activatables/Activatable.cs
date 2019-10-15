using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Activatable : Component
{
    public float cooldown = 1f;

    public virtual Activation GetActivation(Ship ship)
    {
        return new Activation(ship, cooldown, (s) => { });
    }
}

public class Activation
{
    Ship ship;
    float cooldown;
    Action<Ship> onActivation;
    public float cdRemaining = 0f;

    public Activation(Ship ship, float cooldown, Action<Ship> onActivation)
    {
        this.ship = ship;
        this.cooldown = cooldown;
        this.onActivation = onActivation;
    }

    public void Activate()
    {
        if (cdRemaining > 0f)
            return;

        onActivation?.Invoke(ship);
        cdRemaining = cooldown;
    }

    public void Update(float dt)
    {
        if (cdRemaining > 0)
            cdRemaining -= dt;
    }
}
