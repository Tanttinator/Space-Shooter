using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item")]
public class Item : ScriptableObject
{
    new public string name = "Item";
    public float weight;
    public int value;
    public Sprite icon;
}
