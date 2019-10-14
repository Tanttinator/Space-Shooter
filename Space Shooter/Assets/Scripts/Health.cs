using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    float health;

    public UnityEvent onObjectKilled;

    public void Heal(float amount)
    {
        health = Mathf.Min(maxHealth, health + amount);
    }

    public void Damage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        onObjectKilled?.Invoke();
        Destroy(gameObject);
    }

    private void Awake()
    {
        health = maxHealth;
    }
}
