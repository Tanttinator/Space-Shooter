using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hangar : ShipSystem
{
    public Transform spawnPoint;
    public GameObject ship;

    protected override void Effect()
    {
        Instantiate(ship, spawnPoint.position, spawnPoint.rotation);
    }
}
