using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cannon", menuName = "Component/Cannon")]
public class Cannon : Component
{
    [Header("Cannon Stats")]
    //Shots per second
    [Tooltip("Shots per second")] public float fireRate = 1f;
    public float damage = 10f;

    [Header("Projectile Stats")]
    public GameObject prefab;
    public float speed = 10f;
    public float ttl = 10f;

    public void Shoot(Transform cannon, Faction faction)
    {
        GameObject obj = Instantiate(prefab, cannon.position, cannon.rotation);
        obj.GetComponent<Projectile>().Setup(damage, speed, ttl, faction);
    }
}
