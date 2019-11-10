using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : UIElement, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 dragOffset = new Vector2(0, 0);

    RectTransform rt;

    protected virtual void OnDragStart(Vector2 mousePosition)
    {
        dragOffset = rt.anchoredPosition - mousePosition;
    }

    protected virtual void OnDragUpdate(Vector2 mousePosition)
    {
        rt.anchoredPosition = mousePosition + dragOffset;
    }

    protected virtual void OnDragEnd(Vector2 mousePosition)
    {
        dragOffset = new Vector2(0, 0);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.anchorMin = rt.anchorMax = new Vector2(0, 0);
        base.Start();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnDragStart(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragUpdate(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnDragEnd(eventData.position);
    }
}
