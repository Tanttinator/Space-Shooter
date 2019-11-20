using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : ItemDragStart
{
    [SerializeField] Image icon;
    [SerializeField] new Text name;
    [SerializeField] Text costText;

    [SerializeField] Color validColor;
    [SerializeField] Color invalidColor;

    int cost;

    ShopUI shop;
    public override IItemContainer Origin
    {
        get
        {
            return shop as IItemContainer;
        }
    }

    public void Setup(ShopItem item, ShopUI shop)
    {
        this.item = item.item;
        this.shop = shop;
        icon.sprite = item.item.icon;
        name.text = item.item.name;
        cost = item.cost;
        costText.text = cost.ToString();
        shop.onCreditsChanged += OnCreditsChanged;
    }

    void OnCreditsChanged(int credits)
    {
        if (credits < cost)
            costText.color = invalidColor;
        else
            costText.color = validColor;
    }
}
