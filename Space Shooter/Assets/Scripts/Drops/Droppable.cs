using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : ScriptableObject
{
    public GameObject go;

    public virtual GameObject Drop(Vector2 position)
    {
        return Instantiate(go, position + Random.insideUnitCircle * 3f, Quaternion.identity);
    }
}
