using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer
{
    bool OnItemDropped(Item item, IItemContainer origin);
    bool OnItemDragged(Item item);
    void OnDropFailed(Item item);
}
