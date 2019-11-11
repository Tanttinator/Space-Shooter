using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthShip : Health
{
    Ship ship;

    public override float MaxHealth
    {
        get
        {
            return ship.maxHealth;
        }
    }

    float MaxCapacity
    {
        get
        {
            return ship.Shields != null ? ship.Shields.maxCapacity : 0f;
        }
    }
    float ChargeRate
    {
        get
        {
            return ship.Shields != null ? ship.Shields.chargeRate : 0f;
        }
    }
    float DamageMod
    {
        get
        {
            return ship.Shields != null ? ship.Shields.damageMod : 1f;
        }
    }
    float ChargeStartDelay
    {
        get
        {
            return ship.Shields != null ? ship.Shields.chargeStartDelay : 0f;
        }
    }
    float capacity = 0f;
    float chargeDelay = 0f;

    public Action<float, float> onShieldCapacityChanged;

    protected override float CalculateDamage(float dmg)
    {
        float blocked = Mathf.Min(capacity, dmg);
        dmg = dmg - blocked + blocked * DamageMod;
        ChangeShieldCapacity(-blocked);
        return dmg;
    }

    void ChangeShieldCapacity(float amount)
    {
        if (amount < 0)
            chargeDelay = ChargeStartDelay;

        capacity = Mathf.Clamp(capacity + amount, 0f, MaxCapacity);
        onShieldCapacityChanged?.Invoke(capacity, MaxCapacity);
    }

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    protected override void Start()
    {
        ChangeShieldCapacity(MaxCapacity);
        base.Start();
    }

    private void Update()
    {
        if(chargeDelay > 0f)
        {
            chargeDelay -= Time.deltaTime;
        } else
        {
            ChangeShieldCapacity(ChargeRate * Time.deltaTime);
        }
    }
}
