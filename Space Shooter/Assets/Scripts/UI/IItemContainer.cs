using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer
{
    bool OnItemDropped(Item item);
    void OnItemDragged(Item item);
}
