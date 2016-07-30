using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryWindow;
    private Vector3 defaultPos;

    void Awake()
    {
        defaultPos = inventoryWindow.GetComponent<RectTransform>().anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            // Toggle whether the window is active
            inventoryWindow.gameObject.SetActive(!inventoryWindow.gameObject.activeSelf);

            // If active, reset the position of the window to default
            if (inventoryWindow.gameObject.activeSelf)
            {
                inventoryWindow.GetComponent<RectTransform>().anchoredPosition = defaultPos;
            }
        }
    }
}
