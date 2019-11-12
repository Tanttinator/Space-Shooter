using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentsWindow : Window
{
    Ship ship;

    public GameObject activatableSlotGO;
    public Transform slotParent;

    public Image background;
    public List<Slot> slots;

    public override void Show(params object[] args)
    {
        if (isShown)
            return;

        if (args.Length == 0 || !(args[0] is Ship))
        {
            Debug.Log("Wrong parameters supplied to CargoWindow.Show");
            return;
        }
        ship = args[0] as Ship;

        background.sprite = ship.GetComponent<SpriteRenderer>().sprite;

        ship.onComponentSet += OnComponentSet;
        ship.onComponentRemoved += OnComponentRemoved;

        base.Show(args);
        for (int i = 0; i < ship.Activatables.Length - 1; i++)
        {
            GameObject go = Instantiate(activatableSlotGO);
            go.transform.SetParent(slotParent);
            slots.Add(go.GetComponent<Slot>());
        }

        for (int i = 0; i < slots.Count; i++)
        {
            int copy = i;
            slots[i].onItemDropped = (c) => { return ship.SetComponent(c as Component, copy); };
            slots[i].onItemDragged = (c) => { ship.RemoveComponent(copy); };
            if(ship.components[i] != null)
                slots[i].SetItem(ship.components[i]);
        }
    }

    public override void Hide()
    {
        if (!isShown)
            return;
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].onItemDropped = null;
            slots[i].onItemDragged = null;
        }

        while(slots.Count > 5)
        {
            Destroy(slots[5].gameObject);
            slots.RemoveAt(5);
        }

        if (ship != null)
        {
            ship.onComponentSet -= OnComponentSet;
            ship.onComponentRemoved -= OnComponentRemoved;
            ship = null;
        }

        base.Hide();
    }

    void OnComponentSet(Component component, int slot)
    {
        slots[slot].SetItem(component);
    }

    void OnComponentRemoved(int slot)
    {
        slots[slot].RemoveItem();
    }
}
