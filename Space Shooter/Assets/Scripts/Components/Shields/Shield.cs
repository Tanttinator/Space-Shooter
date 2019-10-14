using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Component/Shield")]
public class Shield : Component
{
    [Header("Shield Stats")]
    public float maxCapacity;
    public float chargeRate;
    [Range(0f, 1f)]
    public float damageMod = 0.5f;
    public float chargeStartDelay = 5f;
}
