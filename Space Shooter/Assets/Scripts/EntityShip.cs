using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityShip : Entity
{
    Ship ship;

    protected override float Speed
    {
        get
        {
            return (ship.Engine != null ? ship.Engine.speed : 0f) * speedMod * 25 / ship.Weight;
        }
    }
    protected override float TurnSpeed
    {
        get
        {
            return (ship.Engine != null ? ship.Engine.turnSpeed : 0f) * 300 / ship.Weight;
        }
    }

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }
}
