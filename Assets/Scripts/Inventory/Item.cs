using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public string description;

    public Item(string itemNamem)
    {
        this.itemName = itemNamem;
    }
}
