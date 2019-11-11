using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDraggable : Draggable
{
    public GameObject dragItemGO;
    [HideInInspector] public Item item;
    public virtual IItemContainer Origin
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }
    GameObject currGo = null;

    protected override void OnDragStart(Vector2 mousePosition)
    {
        if (item == null)
            return;
        currGo = Instantiate(dragItemGO);
        currGo.GetComponent<Image>().sprite = item.icon;
        currGo.transform.SetParent(HUD.hudParent);
        dragObject = currGo.GetComponent<RectTransform>();
    }

    protected override void OnDragEnd(Vector2 mousePosition)
    {
        Destroy(currGo);
        currGo = null;
        foreach (UIElement element in UIElement.mouseOver)
        {
            if(element is IItemContainer)
            {
                IItemContainer container = element as IItemContainer;
                if(container.OnItemDropped(item) && Origin != null)
                {
                    Origin.OnItemDragged(item);
                }
                break;
            }
        }
    }
}
