using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : UIElement, IItemContainer
{

    public GameObject itemGO;
    public ScrollView scrollView;

    Shop shop;
    Inventory buyer;

    List<GameObject> itemGOs = new List<GameObject>();

    public void AddItem(ShopItem item)
    {
        GameObject go = Instantiate(itemGO);
        scrollView.AddItem(go);
        go.GetComponent<ShopItemUI>().Setup(item, this);
        itemGOs.Add(go);
    }

    public void SetShop(Shop shop, Inventory buyer)
    {
        ResetShop();
        this.shop = shop;
        this.buyer = buyer;
        foreach (ShopItem item in shop.items)
            AddItem(item);
    }

    public void ResetShop()
    {
        shop = null;
        buyer = null;
        scrollView.Clear();
        itemGOs.Clear();
    }

    public bool OnItemDragged(Item item)
    {
        return shop.BuyItem(item, buyer);
    }

    public bool OnItemDropped(Item item, IItemContainer origin)
    {
        buyer.ChangeCredits(item.value);
        return true;
    }

    public void OnDropFailed(Item item)
    {
        Debug.Log("OnDropFailed");
        ShopItem shopItem = shop.GetItem(item);
        if(shopItem == null)
        {
            buyer.ChangeCredits(item.value);
        }
        else
        {
            buyer.ChangeCredits(shopItem.cost);
        }
    }
}
