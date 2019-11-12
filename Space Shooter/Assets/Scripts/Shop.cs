using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    public ShopItem[] items;

    public bool BuyItem(Item item, Inventory inventory)
    {
        ShopItem shopItem = GetItem(item);
        if (shopItem == null)
            return false;
        if(inventory.credits >= shopItem.cost)
        {
            inventory.ChangeCredits(-shopItem.cost);
            return true;
        }
        return false;
    }

    public ShopItem GetItem(Item item)
    {
        foreach(ShopItem shopItem in items)
        {
            if (shopItem.item = item)
                return shopItem;
        }
        return null;
    }

    public override void OnInteract(Ship ship)
    {
        Inventory inventory = ship.GetComponent<Inventory>();
        FindObjectOfType<ShopWindow>().Show(this, inventory);
    }
}

[System.Serializable]
public class ShopItem
{
    public Item item;
    public int cost;
}
