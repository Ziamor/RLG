using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ItemSlot : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
{
    public BaseItem item;
    public int invIndex;

    private PlayerInventoryWindow inventoryWindow;

    // Use this for initialization
    void Start()
    {
        inventoryWindow = transform.parent.parent.gameObject.GetComponent<PlayerInventoryWindow>();
        if (inventoryWindow == null)
            Debug.LogError("Item slot can't find parent inventory window");

    }

    public void OnDrag(PointerEventData e)
    {

    }

    public void OnBeginDrag(PointerEventData e)
    {
        if (inventoryWindow != null)
        {
            Vector3 dragIconOffset = GetComponent<RectTransform>().position - Input.mousePosition;
            inventoryWindow.StartIconDrag(item, dragIconOffset);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (inventoryWindow != null)
            inventoryWindow.StopIconDrag();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            ItemSlot origin = eventData.pointerDrag.GetComponent<ItemSlot>();
            if (origin == null)
                return;
            inventoryWindow.MoveItem(origin.invIndex, invIndex);
        }
    }
}
