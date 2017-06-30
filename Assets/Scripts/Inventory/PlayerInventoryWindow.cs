using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerInventoryWindow : InventoryWindow
{

    public RectTransform ItemSlotArea;
    public int col_length = 4;
    public int page_count = 16;
    public GameObject itemSlotPref;
    //TODO, decide whether toogle group is helpfull
    public ToggleGroup itemSlotToggleGroup;

    // Use this for initialization
    void Start()
    {
        SetUpWidnow();
        inventory.OnInventoryChanged += OnInventoryChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpWidnow()
    {
        InventoryUI.Instance.dragIcon.SetActive(false);
        InventoryUI.Instance.IconIsDragging = false;

        float x_Pos = ItemSlotArea.transform.position.x;
        float y_Pos = ItemSlotArea.transform.position.y;
        float itemSlot_size;
        GameObject inventorySlots = transform.Find("InventorySlots").gameObject;
        GameObject itemSlot;
        GameObject itemIcon;

        BaseItem[] inventoryItems = inventory.GetInventoryItems();

        for (int i = 0; i < page_count; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPref);
            itemSlot_size = itemSlot.GetComponent<RectTransform>().rect.width;

            float new_x = (i % col_length) * itemSlot_size + x_Pos;
            float new_y = (i / col_length) * itemSlot_size * -1 + y_Pos;

            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(inventorySlots.transform);
            itemSlot.transform.position = new Vector3(new_x, new_y, 0);

            itemIcon = itemSlot.transform.Find("ItemIcon").gameObject;
            if (inventoryItems[i] != null)
            {
                itemSlot.name = inventoryItems[i].itemName;
                //itemSlot.GetComponent<ItemSlot>().item = inventoryItems[i];
                itemSlot.GetComponent<ItemSlot>().invIndex = i;
                itemSlot.GetComponent<ItemSlot>().parent = this;

                itemIcon.SetActive(true);
                itemIcon.GetComponent<Image>().sprite = inventoryItems[i].ItemIcon;
            }
            else
            {
                itemSlot.name = "Empty";
                itemSlot.GetComponent<ItemSlot>().invIndex = i;
                itemSlot.GetComponent<ItemSlot>().parent = this;
                itemIcon.SetActive(false);
            }
        }
    }    


    public override bool Move(ItemSlot source, ItemSlot dest)
    {
        bool success = inventory.MoveItem(source, dest);
        foreach (Transform child in transform.Find("InventorySlots"))
        {
            GameObject.Destroy(child.gameObject);
        }
        SetUpWidnow();
        return success;
    }

    private void OnInventoryChanged()
    {
        SetUpWidnow();
    }
}
