using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseInventory : MonoBehaviour
{

    public BaseItem[] inventoryItems;
    public int inventory_size = 16;

    void Awake()
    {
        inventoryItems = new BaseItem[inventory_size];
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        throw new NotImplementedException();
    }

    public BaseItem[] GetInventoryItems()
    {
        return inventoryItems;
    }

    public bool MoveItem(int origin, int dest)
    {
        // Make sure the origin slot and dest slot are within inv bounds
        if (origin > inventoryItems.Length || dest > inventoryItems.Length)
            return false;
        // If the orgin slot is empty, don't do any moving
        if (inventoryItems[origin] == null)
            return false;

        // If dest slot is empty, simply move the item
        if (inventoryItems[dest] == null)
        {
            inventoryItems[dest] = inventoryItems[origin];
            inventoryItems[origin] = null;
        }
        // If dest isn't empty, we need to swap
        else {
            BaseItem temp = inventoryItems[dest];
            inventoryItems[dest] = inventoryItems[origin];
            inventoryItems[origin] = temp;
        }


        return true;
    }
}
