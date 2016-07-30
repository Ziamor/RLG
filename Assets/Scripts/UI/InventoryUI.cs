using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryWindow;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            inventoryWindow.gameObject.SetActive(!inventoryWindow.gameObject.activeSelf);
        }
    }
}
