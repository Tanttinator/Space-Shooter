using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollView : UIElement
{
    public Transform content;

    public void AddItem(GameObject item)
    {
        item.transform.SetParent(content);
    }
}
