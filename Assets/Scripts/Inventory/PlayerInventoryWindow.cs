using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerInventoryWindow : MonoBehaviour
{

    public RectTransform ItemSlotArea;
    public BaseInventory PlayerInventory;
    public int col_length = 4;
    public int page_count = 16;
    public GameObject itemSlotPref;
    public ToggleGroup itemSlotToggleGroup;
    public GameObject dragIcon;

    private bool iconIsDragging;
    private RectTransform dragIconRectTreansform;
    private Vector3 dragIconOffset;

    // Use this for initialization
    void Start()
    {
        dragIconRectTreansform = dragIcon.GetComponent<RectTransform>();

        // Stops the drag icon from blocking OnDrop
        CanvasGroup group = dragIcon.AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;

        SetUpWidnow();
    }

    // Update is called once per frame
    void Update()
    {
        if (iconIsDragging)
            dragIconRectTreansform.position = Input.mousePosition + dragIconOffset;
    }

    public void SetUpWidnow()
    {
        dragIcon.SetActive(false);
        iconIsDragging = false;

        float x_Pos = ItemSlotArea.transform.position.x;
        float y_Pos = ItemSlotArea.transform.position.y;
        float itemSlot_size;
        GameObject inventorySlots = transform.Find("InventorySlots").gameObject;
        GameObject itemSlot;
        GameObject itemIcon;

        BaseItem[] inventoryItems = PlayerInventory.GetInventoryItems();

        for (int i = 0; i < page_count; i++)
        {
            itemSlot = (GameObject)Instantiate(itemSlotPref);
            itemSlot_size = itemSlot.GetComponent<RectTransform>().rect.width;

            float new_x = (i % col_length) * itemSlot_size + x_Pos;
            float new_y = (i / col_length) * itemSlot_size * -1 + y_Pos;

            itemSlot.GetComponent<Toggle>().group = itemSlotToggleGroup;
            itemSlot.transform.SetParent(inventorySlots.transform);
            itemSlot.transform.position = new Vector3(new_x, new_y, 0);

            itemIcon = itemSlot.transform.FindChild("ItemIcon").gameObject;
            if (inventoryItems[i] != null)
            {
                itemSlot.name = inventoryItems[i].itemName;
                itemSlot.GetComponent<ItemSlot>().item = inventoryItems[i];
                itemSlot.GetComponent<ItemSlot>().invIndex = i;

                itemIcon.SetActive(true);
                itemIcon.GetComponent<Image>().sprite = inventoryItems[i].ItemIcon;
            }
            else
            {
                itemSlot.name = "Empty";
                itemSlot.GetComponent<ItemSlot>().invIndex = i;
                itemIcon.SetActive(false);
            }
        }
    }

    public void StartIconDrag(BaseItem item, Vector3 offset)
    {
        if (item != null)
        {
            iconIsDragging = true;
            dragIcon.SetActive(true);
            dragIcon.GetComponent<Image>().sprite = item.ItemIcon;
            dragIconOffset = offset;
        }
    }

    public void StopIconDrag()
    {
        iconIsDragging = false;
        dragIcon.SetActive(false);
    }

    public void MoveItem(int origin, int dest)
    {
        PlayerInventory.MoveItem(origin, dest);
        foreach (Transform child in transform.Find("InventorySlots"))
        {
            GameObject.Destroy(child.gameObject);
        }
        SetUpWidnow();
    }
}
