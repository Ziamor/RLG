using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private static InventoryUI instance;

    public GameObject inventoryWindow;
    public GameObject dragIcon;

    private Vector3 defaultPos;

    private bool iconIsDragging;
    private RectTransform dragIconRectTreansform;

    private InventoryUI() { }

    public static InventoryUI Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<InventoryUI>() as InventoryUI;
            return instance;
        }
    }

    public bool IconIsDragging
    {
        get { return iconIsDragging; }
        set { iconIsDragging = value; }
    }
    void Awake()
    {
        defaultPos = inventoryWindow.GetComponent<RectTransform>().anchoredPosition;

        // Start the window closed
        inventoryWindow.SetActive(false);
        dragIcon.SetActive(false);
    }

    void Start()
    {
        dragIconRectTreansform = dragIcon.GetComponent<RectTransform>();

        // Stops the drag icon from blocking OnDrop
        CanvasGroup group = dragIcon.AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;
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

        if (iconIsDragging)
            dragIconRectTreansform.position = Input.mousePosition;
    }

    public void StartIconDrag(BaseItem item)
    {
        if (item != null)
        {
            iconIsDragging = true;
            dragIcon.SetActive(true);
            dragIcon.transform.SetAsLastSibling();
            dragIcon.GetComponent<Image>().sprite = item.ItemIcon;
        }
    }

    public void StopIconDrag()
    {
        iconIsDragging = false;
        dragIcon.SetActive(false);
    }
}
