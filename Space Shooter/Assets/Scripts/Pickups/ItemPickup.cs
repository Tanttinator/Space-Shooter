using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Pickup
{
    Item item;
    public void Setup(Item item)
    {
        this.item = item;
        GetComponent<SpriteRenderer>().sprite = item.icon;
    }

    protected override void OnPickup(GameObject obj)
    {
        Inventory inventory = obj.GetComponent<Inventory>();
        inventory?.AddItem(item);
    }
}
