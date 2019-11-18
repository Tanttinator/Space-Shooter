using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles loot dropping for different enemies
[CreateAssetMenu(fileName = "Loot Table", menuName = "Loot Table")]
public class LootTable : ScriptableObject
{
    public List<LootItem> loot;

    public List<Droppable> GetItems()
    {
        List<Droppable> items = new List<Droppable>();
        int total = 0;

        foreach(LootItem item in loot)
        {
            total += item.chance;
        }

        foreach (LootItem item in loot)
        {
            if (item.chance * 1.0f / total > Random.value)
                items.Add(item.item);
            for (int i = 0; i < item.guaranteed; i++)
                items.Add(item.item);
        }

        return items;
    }

    public void Drop(Vector2 position)
    {
        foreach (Droppable item in GetItems())
            item.Drop(position);
    }

    [System.Serializable]
    public struct LootItem
    {
        public Droppable item;
        public int chance;
        public int guaranteed;
    }
}
