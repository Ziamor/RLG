using UnityEngine;
using System.Collections;

public abstract class InventoryWindow : MonoBehaviour {
    public BaseInventory inventory;
    public abstract bool Move(ItemSlot source, ItemSlot dest);
    //public abstract void OnInventoryChanged();
}
