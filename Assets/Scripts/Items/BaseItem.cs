using UnityEngine;
using System.Collections;
using System;
using Newtonsoft.Json;

public enum ItemType { UNTYPED, EQUIPMENT, CONSUMABLE, CRAFTING, KEY };

[JsonConverter(typeof(ItemConverter))]
public class BaseItem
{
    public string itemName = "NULL";
    public string itemDesc = "NULL";
    public float itemValue = -1;
    public ItemType itemType = ItemType.UNTYPED;
    public int spriteID = 0;

    // undefinedItem is used in place for a null item
    public static BaseItem undefinedItem = new BaseItem(); // TODO fill out default item properties

    private Sprite itemIcon = null;

    [JsonIgnore]
    public Sprite ItemIcon
    {
        get
        {
            if (itemIcon == null)
                itemIcon = Resources.LoadAll<Sprite>("Sprites/Objects")[spriteID];
            return itemIcon;
        }
        set { itemIcon = value; }
    }
}
