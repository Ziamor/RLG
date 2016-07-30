using UnityEngine;
using System.Collections;
using System;

public enum ItemType { UNTYPED, EQUIPMENT, CONSUMABLE, CRAFTING, KEY };

[Serializable]
public class BaseItem
{
    public string itemName = "NULL";
    public string itemDesc = "NULL";
    public float itemValue = -1;
    public ItemType itemType = ItemType.UNTYPED;
    public int spriteID = 0;

    private Sprite itemIcon = null;


    public Sprite ItemIcon
    {
        get
        {
            if(itemIcon == null)
            {
                itemIcon = Resources.LoadAll<Sprite>("Sprites/Objects")[spriteID];
            }
            return itemIcon;
        }
        set { itemIcon = value; }
    }
}
