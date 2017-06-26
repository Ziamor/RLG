using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseInventory : MonoBehaviour
{

    public BaseItem[] inventoryItems;
    public int inventory_size = 16;
    // Event Handler
    public delegate void OnInventoryChangedEvent();
    public event OnInventoryChangedEvent OnInventoryChanged;

    public int Length
    {
        get { return inventoryItems.Length; }
    }

    void Awake()
    {
        inventoryItems = new BaseItem[inventory_size];
    }

    public bool AddItemToInventory(String item_Name)
    {
        // Get the item from the database
        BaseItem item = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>().GetItem(item_Name);
        if (item != null)
            return AddItemToInventory(item);
        else
            return false;
    }

    public bool AddItemToInventory(BaseItem item)
    {
        // Find first available index to insert item
        for (int i = 0; i < inventoryItems.Length; i++)
            if (inventoryItems[i] == null)
            {
                inventoryItems[i] = item;
                return true;
            }
        // No free spot was found, the inventory is full
        return false;
    }

    public bool AddItemToInventory(BaseItem item, int index)
    {
        if (index > inventoryItems.Length || item == null)
            return false;
        if (inventoryItems[index] != null)
            return false;
        inventoryItems[index] = item;
        return true;
    }

    public BaseItem RemoveItem(int index)
    {
        if (index > inventoryItems.Length)
            return null;

        BaseItem removedItem = inventoryItems[index];
        inventoryItems[index] = null;
        return removedItem;
    }

    public BaseItem GetItem(int index)
    {
        if (index > inventoryItems.Length)
            return null;
        return inventoryItems[index];
    }

    public bool IsInventoryFull()
    {
        for (int i = 0; i < inventoryItems.Length; i++)
            // If we find an empty slot, the inventory is not full
            if (inventoryItems[i] == null)
                return false;
        // No free spot was found, the inventory is full
        return true;
    }

    public void Resize(int newSize)
    {
        //TODO resize without destroying items
        inventory_size = newSize;
        inventoryItems = new BaseItem[newSize];
    }

    public BaseItem[] GetInventoryItems()
    {
        return inventoryItems;
    }

    /*public bool MoveItem(int source, int dest)
    {
        // Make sure the source slot and dest slot are within inv bounds
        if (source > inventoryItems.Length || dest > inventoryItems.Length)
            return false;
        // If the source slot is empty, don't do any moving
        if (inventoryItems[source] == null)
            return false;

        // If dest slot is empty, simply move the item
        if (inventoryItems[dest] == null)
        {
            inventoryItems[dest] = inventoryItems[source];
            inventoryItems[source] = null;
        }
        // If dest isn't empty, we need to swap
        else
        {
            BaseItem temp = inventoryItems[dest];
            inventoryItems[dest] = inventoryItems[source];
            inventoryItems[source] = temp;
        }


        return true;
    }*/

    public bool MoveItem(ItemSlot source, ItemSlot dest)
    {
        bool success = true;

        // Make sure the source slot and dest slot are within inv bounds
        if (!source.IsValidInventoryPosition() || !dest.IsValidInventoryPosition())
            return false;
        // If the source slot is empty, don't do any moving
        if (source.Item == null)
            return false;
        // If dest slot is empty, simply move the item
        if (dest.Item == null)
        {
            if (dest.Inventory.AddItemToInventory(source.Item, dest.invIndex))
                source.Inventory.RemoveItem(source.invIndex);
            else
                success = false;

        }
        // If dest isn't empty, we need to swap
        else
        {

            BaseItem sourceItem = source.Inventory.RemoveItem(source.invIndex);
            BaseItem destItem = dest.Inventory.RemoveItem(dest.invIndex);
            if (sourceItem != null && destItem != null)
            {
                if (dest.Inventory.AddItemToInventory(sourceItem, dest.invIndex))
                    success = source.Inventory.AddItemToInventory(destItem, source.invIndex);
            }
            else
                success = false;
        }

        source.Inventory.OnInventoryChanged();
        dest.Inventory.OnInventoryChanged();

        return success;
    }
}
