using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Activatable : Component
{
    public float cooldown = 1f;

    public virtual Activation GetActivation(Ship ship)
    {
        return new Activation(cooldown, () => { });
    }
}

public class Activation
{
    float cooldown;
    Action onActivation;
    Action onActivationDown;
    Action onActivationUp;
    public float cdRemaining = 0f;
    bool active = false;

    public Activation(float cooldown, Action onActivationDown, Action onActivationUp = null, Action onActivation = null)
    {
        this.cooldown = cooldown;
        this.onActivation = onActivation;
        this.onActivationDown = onActivationDown;
        this.onActivationUp = onActivationUp;
    }

    public void Activate()
    {
        if (active)
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
