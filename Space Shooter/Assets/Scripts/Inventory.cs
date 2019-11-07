﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Ship))]
public class Inventory : MonoBehaviour
{
    public int credits = 0;

    public float MaxCargoSpace
    {
        get
        {
            return ship.cargoSpace;
        }
    }
    public float CargoSpace
    {
        get
        {
            float i = 0;
            foreach (ItemStack stack in inventory)
                i += stack.item.weight * stack.count;
            return i;
        }
    }

    Ship ship;

    List<ItemStack> inventory = new List<ItemStack>();

    public Action<Item, int> onItemAdded;
    public Action<Item, int> onItemRemoved;

    public bool AddItem(Item item)
    {
        if(CargoSpace + item.weight <= MaxCargoSpace)
        {
            int index = IndexOf(item);
            if (index != -1)
                inventory[index].count++;
            else
                inventory.Add(new ItemStack(item));
            onItemAdded?.Invoke(item, AmountOf(item));
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveItem(Item item)
    {
        int index = IndexOf(item);
        bool success = false;
        if (index != -1)
        {
            if (inventory[index].count > 0)
            {
                inventory[index].count--;
                onItemRemoved?.Invoke(item, AmountOf(item));
                success = true;
            }
            if (inventory[index].count == 0)
                inventory.RemoveAt(index);
        }
        return success;
    }

    public int IndexOf(Item item)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].item == item)
                return i;
        }
        return 0;
    }

    public int AmountOf(Item item)
    {
        int index = IndexOf(item);
        if(index != -1)
        {
            return inventory[index].count;
        }
        return -1;
    }

    private void Awake()
    {
        ship = GetComponent<Ship>();
    }
}

public class ItemStack
{
    public Item item;
    public int count;

    public ItemStack(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }

    public ItemStack(Item item) : this(item, 1)
    {

    }
}
