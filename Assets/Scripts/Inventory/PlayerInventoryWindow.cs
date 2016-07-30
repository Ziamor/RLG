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

    // Use this for initialization
    void Start()
    {
        SetUpWidnow();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetUpWidnow()
    {
        float x_Pos = ItemSlotArea.transform.position.x;
        float y_Pos = ItemSlotArea.transform.position.y;
        float itemSlot_size;
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
            itemSlot.transform.SetParent(this.gameObject.transform);
            itemSlot.transform.position = new Vector3(new_x, new_y, 0);

            itemIcon = itemSlot.transform.FindChild("ItemIcon").gameObject;
            if (i < inventoryItems.Length && inventoryItems[i] != null)
            {
                itemSlot.name = inventoryItems[i].itemName;
                itemIcon.SetActive(true);
                itemIcon.GetComponent<Image>().sprite = inventoryItems[i].ItemIcon;
            }
            else
            {
                itemSlot.name = "Empty";
                itemIcon.SetActive(false);
            }
        }
    }
}
