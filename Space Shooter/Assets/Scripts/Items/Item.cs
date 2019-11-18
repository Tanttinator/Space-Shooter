using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item")]
public class Item : Droppable
{
    new public string name = "Item";
    public float weight;
    public int value;
    public Sprite icon;

    public override GameObject Drop(Vector2 position)
    {
        GameObject go = base.Drop(position);
        go.GetComponent<ItemPickup>().Setup(this);
        return go;
    }
}
