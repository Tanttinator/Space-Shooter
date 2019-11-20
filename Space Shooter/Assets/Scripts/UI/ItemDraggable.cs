using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDraggable : Draggable
{
    Item item;
    [HideInInspector] public IItemContainer origin;

    public void SetItem(Item item)
    {
        this.item = item;
        GetComponent<Image>().sprite = item.icon;
    }

    protected override void OnDragStart(Vector2 mousePosition)
    {
        base.OnDragStart(mousePosition);
        dragOffset = new Vector2(0, 0);
    }

    protected override void OnDragEnd(Vector2 mousePosition)
    {
        bool success = false;
        foreach (UIElement element in UIElement.mouseOver)
        {
            if(element is IItemContainer)
            {
                IItemContainer container = element as IItemContainer;
                if (container.OnItemDropped(item, origin))
                    success = true;
            }
        }
        if(!success && origin != null)
            origin.OnDropFailed(item);
        Destroy(gameObject);
    }

    private void Awake()
    {
        OnDragStart(Input.mousePosition);
    }
}
