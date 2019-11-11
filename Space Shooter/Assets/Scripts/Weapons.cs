using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    Ship ship;
    public List<Transform> cannons;

    int cannonId = 0;

    public void Shoot()
    {
        ship.Cannon.Shoot(cannons[cannonId], ship.health.faction);
        if (cannonId == cannons.Count - 1)
            cannonId = 0;
        else
            cannonId++;
    }

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }
}
