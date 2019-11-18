using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpack : Pickup
{
    [HideInInspector] public int amount = 25;

    protected override void OnPickup(GameObject obj)
    {
        Health health = obj.GetComponent<Health>();
        health?.Heal(amount);
    }
}
