using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : ItemDragStart
{
    [SerializeField] Image icon;
    [SerializeField] new Text name;
    [SerializeField] Text count;

    InventoryUI inventory;
    public override IItemContainer Origin
    {
        get
        {
            return inventory as IItemContainer;
        }
    }

    public void Setup(Item item, InventoryUI inventory)
    {
        this.item = item;
        this.inventory = inventory;
        icon.sprite = item.icon;
        name.text = item.name;
        count.text = "1";
    }

    public void SetCount(int count)
    {
        this.count.text = count.ToString();
    }
}
