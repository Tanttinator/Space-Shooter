using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masterclass for all interactable systems in a ship
public class ShipSystem : MonoBehaviour
{
    public float cooldown = 1f;
    float cooldownProgress = 0f;
    bool canActivate
    {
        get
        {
            return cooldownProgress <= 0f;
        }
    }

    public void Activate()
    {
        if (!canActivate)
            return;
        Effect();
        cooldownProgress = cooldown;
    }

    protected virtual void Effect()
    {

    }

    protected virtual void Update()
    {
        if(!canActivate)
        {
            cooldownProgress -= Time.deltaTime;
        }
    }
}
