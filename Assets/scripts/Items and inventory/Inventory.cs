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
        //Debug.Log(itemList.Count);
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        //Item itemInInventory = null;
        //foreach (Item inventoryItem in itemList)
        //{
        //    if (inventoryItem.itemType == item.itemType)
        //    {
        //        inventoryItem.amount -= item.amount;
        //        itemInInventory = inventoryItem;
        //    }
        //    if (itemInInventory != null && itemInInventory.amount <= 0)
        //    {
        //        itemList.Remove(itemInInventory);
        //    }
        //}

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<Item> GetItemList()
    {
        return itemList;
    }
    
    public bool CheckForItemOfType(Item.ItemType i)
    {
        foreach (Item item in itemList)
        {
            if (item.itemType == i)
            {
                //Debug.Log("Found a fish item!");
                return true;
                // Do whatever you want when a fish item is found
                //break; // Stop the loop once a fish item is found
            }
            
        }
        return false;
    }
    public Item GetFirstItemOfType(Item.ItemType i)
    {
        foreach (Item item in itemList)
        {
            if (item.itemType == i)
            {
                //Debug.Log("Found a fish item!");
                return item;
                // Do whatever you want when a fish item is found
                //break; // Stop the loop once a fish item is found
            }

        }
        return null;

    }
}
