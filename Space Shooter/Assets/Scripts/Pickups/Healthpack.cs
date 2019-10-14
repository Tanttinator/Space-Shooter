using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : Pickup
{
    public int amount = 25;

    protected override bool OnPickup(GameObject obj)
    {
        Health health = obj.GetComponent<Health>();
        if(health != null)
        {
            health.Heal(amount);
            return true;
        }
        return false;
    }
}
