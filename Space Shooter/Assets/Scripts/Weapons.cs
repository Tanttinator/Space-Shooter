using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    Ship ship;
    public List<Transform> cannons;

    int cannonId = 0;
    float cooldown = 0f;

    public void Shoot()
    {
        if (cooldown > 0f)
            return;

        ship.cannon.Shoot(cannons[cannonId], ship.health.faction);
        cooldown = 1f / ship.cannon.fireRate;
        if (cannonId == cannons.Count - 1)
            cannonId = 0;
        else
            cannonId++;
    }

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }

    private void Update()
    {
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
    }
}
