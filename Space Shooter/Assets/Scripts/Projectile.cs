using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float ttl = 10f;
    float time = 0f;

    Faction faction;
    bool isSetup = false;

    public void Setup(Faction faction)
    {
        this.faction = faction;
        isSetup = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSetup)
            return;
        Health health = collision.GetComponent<Health>();
        if(health == null || faction.IsEnemy(collision.GetComponent<FactionContainer>().faction))
        {
            health?.Damage(damage * (1 - Mathf.Pow(time, 2) / Mathf.Pow(ttl, 2)));
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
