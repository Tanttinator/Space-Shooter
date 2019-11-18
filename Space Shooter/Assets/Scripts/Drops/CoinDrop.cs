using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin", menuName = "Drop/Coin")]
public class CoinDrop : Droppable
{
    public int minValue;
    public int maxValue;

    public override GameObject Drop(Vector2 position)
    {
        GameObject go = base.Drop(position);
        go.GetComponent<Coin>().minValue = minValue;
        go.GetComponent<Coin>().maxValue = maxValue;
        return go;
    }
}
