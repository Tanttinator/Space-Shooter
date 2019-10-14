using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Masterclass for all interactable systems in a ship
[RequireComponent(typeof(Ship))]
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
    protected Ship owner;

    //Handles user activation of the system
    public void Activate()
    {
        if (!canActivate)
            return;
        Effect();
        cooldownProgress = Cooldown();
    }

    //What happens when this system is activated
    protected virtual void Effect()
    {

    }

    //How is cooldown calculated
    protected virtual float Cooldown()
    {
        return cooldown;
    }

    private void Start()
    {
        owner = GetComponent<Ship>();
    }

    protected virtual void Update()
    {
        if(!canActivate)
        {
            cooldownProgress -= Time.deltaTime;
        }
    }
}
