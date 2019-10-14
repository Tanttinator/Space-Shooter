using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionContainer : MonoBehaviour
{
    public Faction faction;

    private void Update()
    {
        if (faction == null)
            Debug.LogError(gameObject.name + " NO FACTION SET!!");
    }
}
