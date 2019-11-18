using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Healthpack", menuName = "Drop/Healthpack")]
public class HealthpackDrop : Droppable
{
    public int amount;

    public override GameObject Drop(Vector2 position)
    {
        GameObject go = base.Drop(position);
        go.GetComponent<Healthpack>().amount = amount;
        return go;
    }
}
