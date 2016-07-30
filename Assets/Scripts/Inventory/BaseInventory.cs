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
                Debug.Log("Added new item to inventory, " + item.itemName);
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
}
