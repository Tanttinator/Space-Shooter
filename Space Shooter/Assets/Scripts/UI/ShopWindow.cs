using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : Window
{

    public ShopUI shop;

    public override void Show(params object[] args)
    {
        if (args.Length == 0 || !(args[0] is Shop))
        {
            Debug.Log("Wrong parameters given to ShopWindow.Show");
            return;
        }
        if(args.Length == 1 || !(args[1] is Inventory))
        {
            Debug.Log("Wrong parameters given to ShopWindow.Show");
            return;
        }

        base.Show(args);
        shop.SetShop(args[0] as Shop, args[1] as Inventory);
    }

    public override void Hide()
    {
        shop.ResetShop();
        base.Hide();
    }
}
