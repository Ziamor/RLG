using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ItemSlot : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
{
    //public BaseItem item;
    public int invIndex;
    public InventoryWindow parent;

    public BaseItem Item
    {
        get
        {
            if (Inventory != null)
                return Inventory.GetItem(invIndex);
            return null;
        }        
    }

    public BaseInventory Inventory
    {
        get
        {
            if (parent == null)
                return null;
            return parent.inventory;
        }
    }
    // Use this for initialization
    void Start()
    {

    }

    public void OnDrag(PointerEventData e)
    {

    }

    public void OnBeginDrag(PointerEventData e)
    {
        InventoryUI.Instance.StartIconDrag(Item);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        InventoryUI.Instance.StopIconDrag();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (parent == null)
            return;

        if (eventData.pointerDrag != null)
        {
            ItemSlot origin = eventData.pointerDrag.GetComponent<ItemSlot>();
            if (origin == null)
                return;
            parent.Move(origin, this);
        }
    }

    public bool IsValidInventoryPosition()
    {
        if (invIndex > Inventory.Length)
            return false;
        return true;
    }
}
