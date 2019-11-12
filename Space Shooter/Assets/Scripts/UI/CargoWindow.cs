using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoWindow : Window
{
    public InventoryUI inventory;

    public override void Show(params object[] args)
    {
        if(args.Length == 0 || !(args[0] is Inventory))
        {
            Debug.Log("Wrong parameters given to CargoWindow.Show");
            return;
        }

        base.Show(args);
        inventory.SetInventory(args[0] as Inventory);

    }

    public override void Hide()
    {
        inventory.ResetInventory();
        base.Hide();
    }
}
