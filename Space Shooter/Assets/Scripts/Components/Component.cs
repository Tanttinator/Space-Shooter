﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : ScriptableObject
{
    [Header("Component Stats")]
    public string displayName;
    public float weight;
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
