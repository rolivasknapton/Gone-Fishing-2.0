using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        /*
        AddItem(new Item { itemType = Item.ItemType.Cube, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Hand, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Fish, amount = 1 });
        */
        Debug.Log(itemList.Count);
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
}