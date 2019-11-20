using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : UIElement
{
    protected Vector2 dragOffset = new Vector2(0, 0);

    protected RectTransform dragObject;

    protected bool isDragging = false;

    protected virtual void OnDragStart(Vector2 mousePosition)
    {
        isDragging = true;
        dragObject = GetComponent<RectTransform>();
        dragObject.anchorMin = dragObject.anchorMax = new Vector2(0, 0);
        dragOffset = dragObject.anchoredPosition - mousePosition;
    }

    protected virtual void OnDragUpdate(Vector2 mousePosition)
    {
        if(dragObject != null)
            dragObject.anchoredPosition = mousePosition + dragOffset;
    }

    protected virtual void OnDragEnd(Vector2 mousePosition)
    {
        isDragging = false;
        dragOffset = new Vector2(0, 0);
    }

    protected override void Update()
    {
        if(isDragging)
        {
            OnDragUpdate(Input.mousePosition);
            if(Input.GetMouseButtonUp(0))
            {
                OnDragEnd(Input.mousePosition);
            }
        } else
        {
            if(Input.GetMouseButtonDown(0) && isMouseOver)
            {
                Focus();
                OnDragStart(Input.mousePosition);
            }
        }
        base.Update();
    }

    protected override void Start()
    {
        base.Start();
    }
}
