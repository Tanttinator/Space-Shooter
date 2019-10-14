using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Health : MonoBehaviour
{
    public Hull hull;
    public Shield shield;

    public float health { get; protected set; }

    public Action onObjectKilled;
    public Action<float, float> onHealthChanged;

    public LootTable loot;

    public Sound deathSound;

    public void Heal(float amount)
    {
        health = Mathf.Min(hull.maxHealth, health + amount);
        onHealthChanged?.Invoke(health, hull.maxHealth);
    }

    public void Damage(float amount)
    {
        health = Mathf.Max(health - amount, 0);
        onHealthChanged?.Invoke(health, hull.maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(loot != null)
        {
            foreach (GameObject item in loot.Drop())
                Instantiate(item, (Vector2)transform.position + UnityEngine.Random.insideUnitCircle, Quaternion.identity);
        }
        if (deathSound != null)
            SoundHandler.Play(deathSound, transform.position);
        onObjectKilled?.Invoke();
        Destroy(gameObject);
    }

    private void Awake()
    {
        health = hull.maxHealth;
    }
}
