using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Slot : ItemDraggable, IItemContainer
{
    public Image image;
    public Sprite defaultIcon;

    public Func<Item, bool> onItemDropped;
    public Action<Item> onItemDragged;

    public override IItemContainer Origin
    {
        get
        {
            return this as IItemContainer;
        }
    }

    public void SetItem(Item item)
    {
        this.item = item;
        image.sprite = item.icon;
    }

    public void RemoveItem()
    {
        item = null;
        image.sprite = defaultIcon;
    }

    private void OnValidate()
    {
        if (defaultIcon != null && image != null)
            image.sprite = defaultIcon;
    }

    public bool OnItemDropped(Item item)
    {
        if (onItemDropped == null)
            return false;
        else
            return onItemDropped.Invoke(item);
    }

    public void OnItemDragged(Item item)
    {
        onItemDragged?.Invoke(item);
    }
}
