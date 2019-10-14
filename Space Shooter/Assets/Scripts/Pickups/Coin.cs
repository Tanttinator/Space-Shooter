using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickup
{
    public int minValue = 1;
    public int maxValue = 3;

    protected override bool OnPickup(GameObject obj)
    {
        Inventory inv = obj.GetComponent<Inventory>();
        if (inv != null)
        {
            inv.credits += Random.Range(minValue, maxValue);
            return true;
        }
        return false;
    }
}
