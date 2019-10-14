using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Component/Shield")]
public class Shield : Component
{
    [Header("Shield Stats")]
    public int maxCapacity;
    public float refreshRate;
}
