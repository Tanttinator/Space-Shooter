using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    float health = 0f;

    public Faction faction;
    public Sound deathSound;
    public LootTable loot;

    public Action<float, float> onHealthChanged;
    public Action onDeath;

    public virtual float MaxHealth
    {
        get
        {
            return 100f;
        }
    }

    public void Heal(float amount)
    {
        ChangeHealth(amount);
    }

    public void Damage(float amount)
    {
        ChangeHealth(-CalculateDamage(amount));

        if(health == 0)
        {
            Die();
        }
    }

    void ChangeHealth(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, MaxHealth);
        onHealthChanged?.Invoke(health, MaxHealth);
    }

    protected virtual float CalculateDamage(float dmg)
    {
        return dmg;
    }

    void Die()
    {
        onDeath?.Invoke();
        loot?.Drop(transform.position);
        SoundHandler.Play(deathSound, transform.position);
        Destroy(gameObject);
    }

    protected virtual void Start()
    {
        ChangeHealth(MaxHealth);
    }
}
