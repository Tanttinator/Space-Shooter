using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : Item
{
    [Header("Component Stats")]
    public HullType hullType;

    public virtual void OnEquip(Ship ship)
    {

    }
}

public enum HullType
{
    LIGHT,
    MEDIUM,
    LARGE,
    CAPITAL
}
