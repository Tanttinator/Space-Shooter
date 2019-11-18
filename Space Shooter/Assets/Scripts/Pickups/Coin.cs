using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickup
{
    [HideInInspector] public int minValue = 1;
    [HideInInspector] public int maxValue = 3;

    protected override void OnPickup(GameObject obj)
    {
        Inventory inv = obj.GetComponent<Inventory>();
        if (inv != null)
        {
            inv.ChangeCredits(Random.Range(minValue, maxValue));
        }
    }
}
