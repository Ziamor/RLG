using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public TextAsset itemsJson;
    private Dictionary<string, BaseItem> items;

    void Awake()
    {
        items = new Dictionary<string, BaseItem>();
        /*BaseEquipment oldSword = new BaseEquipment();
        oldSword.damage = 10;
        oldSword.speed = 1;
        oldSword.itemValue = 5;
        oldSword.itemName = "Old Sword";
        oldSword.itemDesc = "An old beat up sword.";
        oldSword.ItemIcon = Resources.LoadAll<Sprite>("Sprites/Objects")[14];
        items.Add(oldSword.itemName, oldSword);*/

        BaseItem[] weapons = JsonHelper.getJsonArray<BaseItem>(itemsJson.text);
        for (int i = 0; i < weapons.Length; i++)
            AddNewItem(weapons[i]);
    }

    // Update is called once per frame
    void Update()
    {

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
