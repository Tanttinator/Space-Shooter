using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : UIElement, IItemContainer
{
    public Inventory inventory;
    public GameObject itemGO;
    public ScrollView scrollView;

    public Text creditsCount;
    public Text cargoSpace;

    Dictionary<Item, ItemUI> itemGOs = new Dictionary<Item, ItemUI>();

    void AddItem(Item item, int count)
    {
        if(itemGOs.ContainsKey(item))
        {
            itemGOs[item].SetCount(count);
        }
        else
        {
            GameObject go = Instantiate(itemGO);
            go.GetComponent<ItemUI>().Setup(item, this);
            scrollView.AddItem(go);
            itemGOs.Add(item, go.GetComponent<ItemUI>());
        }
    }

    void RemoveItem(Item item, int count)
    {
        if(count > 0)
        {
            itemGOs[item].SetCount(count);
        }
        else
        {
            Destroy(itemGOs[item].gameObject);
            itemGOs.Remove(item);
        }
    }

    void SetCredits(int amount)
    {
        if(creditsCount != null)
            creditsCount.text = amount.ToString();
    }

    void SetCargoSpace(float space, float maxSpace)
    {
        if(cargoSpace != null)
            cargoSpace.text = space + "/" + maxSpace;
    }

    public void SetInventory(Inventory inventory)
    {
        ResetInventory();
        this.inventory = inventory;
        foreach (ItemStack stack in inventory.GetInventory())
            AddItem(stack.item, stack.count);
        SetCargoSpace(inventory.CargoSpace, inventory.MaxCargoSpace);
        SetCredits(inventory.credits);
        inventory.onItemAdded += AddItem;
        inventory.onItemRemoved += RemoveItem;
        inventory.onCargoSpaceChanged += SetCargoSpace;
        inventory.onCreditsChanged += SetCredits;
    }

    public void ResetInventory()
    {
        scrollView.Clear();
        itemGOs.Clear();
        if (inventory == null)
            return;
        inventory.onItemAdded -= AddItem;
        inventory.onItemRemoved -= RemoveItem;
        inventory.onCargoSpaceChanged -= SetCargoSpace;
        inventory.onCreditsChanged -= SetCredits;
        inventory = null;
    }

    public bool OnItemDropped(Item item, IItemContainer origin)
    {
        return inventory.AddItem(item);
    }

    public bool OnItemDragged(Item item)
    {
        inventory.RemoveItem(item);
        return true;
    }

    public void OnDropFailed(Item item)
    {
        inventory.AddItem(item);
    }
}
