using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragStart : UIElement, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Item item;
    public GameObject dragItemGO;
    Item draggedItem = null;

    public virtual IItemContainer Origin
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedItem = item;
        if (draggedItem == null || (Origin != null && !Origin.OnItemDragged(draggedItem)))
            return;
        GameObject currGo = Instantiate(dragItemGO);
        if (draggedItem.icon != null)
            currGo.GetComponent<Image>().sprite = draggedItem.icon;
        currGo.transform.SetParent(HUD.hudParent);
        currGo.GetComponent<ItemDraggable>().item = draggedItem;
        currGo.GetComponent<ItemDraggable>().origin = Origin;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
