using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Draggable
{
    public override void Show(params object[] args)
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector2(150, 280);
        Focus();
        base.Show(args);
    }
}
