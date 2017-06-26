using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{
    private static ItemDatabase instance;

    public TextAsset itemsJson;
    private Dictionary<string, BaseItem> items;
    private bool itemsLoaded = false;

    private ItemDatabase() { }

    public static ItemDatabase Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ItemDatabase>() as ItemDatabase;
            return instance;
        }
    }

    public bool ItemsLoaded
    {
        get { return itemsLoaded; }
    }

    void Awake()
    {
        if (!itemsLoaded)
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Load()
    {
        items = new Dictionary<string, BaseItem>();
        /*BaseEquipment oldSword = new BaseEquipment();
        oldSword.damage = 10;
        oldSword.speed = 1;
        oldSword.itemValue = 5;
        oldSword.itemName = "Old Sword";
        oldSword.itemDesc = "An old beat up sword.";
        oldSword.ItemIcon = Resources.LoadAll<Sprite>("Sprites/Objects")[14];
        oldSword.slotType = SlotType.MAIN_HAND;
        items.Add(oldSword.itemName, oldSword);*/

        BaseItem[] itemsFromJson = JsonConvert.DeserializeObject<BaseItem[]>(itemsJson.text);
        for (int i = 0; i < itemsFromJson.Length; i++)
            AddNewItem(itemsFromJson[i]);

        itemsLoaded = true;
        //Debug.Log(JsonConvert.SerializeObject(oldSword));
        //BaseItem itemsTest = JsonConvert.DeserializeObject<BaseItem>(itemsJson.text);
        // Debug.Log(((BaseEquipment)itemsTest).damage);
    }

    public void AddNewItem(BaseItem newItem)
    {
        items.Add(newItem.itemName, newItem);
    }

    public BaseItem GetItem(string name)
    {
        BaseItem wantedItem = null;
        items.TryGetValue(name, out wantedItem);
        return wantedItem;
    }
}
