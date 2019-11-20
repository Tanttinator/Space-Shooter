using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool startHidden = false;

    public static List<UIElement> mouseOver = new List<UIElement>();
    public bool isMouseOver
    {
        get
        {
            return mouseOver.Count > 0 && mouseOver[0] == this;
        }
    }

    protected bool isShown = true;

    public virtual void Show(params System.Object[] args)
    {
        if (isShown)
            return;
        isShown = true;
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public virtual void Hide()
    {
        if (!isShown)
            return;
        isShown = false;
        transform.localScale = new Vector3(0f, 0f, 0f);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (startHidden)
            Hide();
    }

    protected virtual void Update()
    {

    }

    protected void Focus()
    {
        Debug.Log("Focus");
        transform.SetAsLastSibling();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver.Insert(0, this);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        mouseOver.Remove(this);
    }
}
