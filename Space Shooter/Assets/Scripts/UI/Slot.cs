using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : UIElement
{
    public Image image;
    public Sprite defaultIcon;

    Item item;

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
}
