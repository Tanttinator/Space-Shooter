using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static Transform hudParent;

    private void Awake()
    {
        hudParent = transform;
    }
}
