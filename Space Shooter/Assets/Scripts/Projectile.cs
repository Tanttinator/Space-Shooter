using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    float damage;
    float speed;
    float ttl;

    float time = 0f;
    Faction faction;
    bool isSetup = false;

    public void Setup(float damage, float speed, float ttl, Faction faction)
    {
        this.damage = damage;
        this.speed = speed;
        this.ttl = ttl;
        this.faction = faction;
        isSetup = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSetup)
            return;
        Health health = collision.GetComponent<Health>();
        if(health == null || faction.IsEnemy(health.faction))
        {
            health?.Damage(damage / (1 + time / ttl));
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!isSetup)
            return;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        time += Time.deltaTime;
        if (time >= ttl)
            Destroy(gameObject);
    }
}
