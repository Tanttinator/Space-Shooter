using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollView : UIElement
{
    public Transform content;
    List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        item.transform.SetParent(content);
        items.Add(item);
    }

    public void Clear()
    {
        while (items.Count > 0)
        {
            Destroy(items[0]);
            items.RemoveAt(0);
        }
    }
}
