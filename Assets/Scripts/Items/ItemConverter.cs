using System;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ItemConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return typeof(BaseItem).IsAssignableFrom(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Load JObject from stream
        JObject jObject = JObject.Load(reader);

        // Create target object based on JObject
        BaseItem target = CreateItem(objectType, jObject);

        // Populate the object properties
        serializer.Populate(jObject.CreateReader(), target);

        return target;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        /*BaseItem item = (BaseItem)value;

        writer.WriteStartObject();

        writer.WritePropertyName("itemName");
        writer.WriteValue(item.itemName);

        writer.WritePropertyName("itemDesc");
        writer.WriteValue(item.itemDesc);

        writer.WritePropertyName("itemValue");
        writer.WriteValue(item.itemValue);

        writer.WritePropertyName("itemType");
        writer.WriteValue(Enum.GetName(item.itemType.GetType(), item.itemType));

        writer.WritePropertyName("spriteID");
        writer.WriteValue(item.spriteID);

        if (value is BaseEquipment)
        {
            BaseEquipment itemEquip = (BaseEquipment)value;

            writer.WritePropertyName("slotType");
            writer.WriteValue(Enum.GetName(itemEquip.slotType.GetType(), itemEquip.slotType));

            writer.WritePropertyName("damage");
            writer.WriteValue(itemEquip.damage);

            writer.WritePropertyName("speed");
            writer.WriteValue(itemEquip.speed);
        }
        writer.WriteEndObject();*/
        Debug.LogError("Trying to convert items into JSON.");
    }

    protected BaseItem CreateItem(Type objectType, JObject jObject)
    {
        if (jObject["itemType"] != null)
        {
            switch (jObject["itemType"].ToString())
            {
                case "EQUIPMENT":
                    return new BaseEquipment();
                case "INGREDIENT":
                    return CreateIngredient(objectType, jObject);
                default:
                    Debug.Log("Error reading item type from JSON");
                    return BaseItem.undefinedItem;
            }
        }
        Debug.Log("Error reading item type from JSON");
        return BaseItem.undefinedItem;
    }

    protected BaseItem CreateIngredient(Type objectType, JObject jObject)
    {
        if (jObject["ingredientType"] != null)
        {
            switch (jObject["ingredientType"].ToString())
            {
                case "ORE":
                    return new BaseOre();
                case "METAL":
                    return new BaseIngredient();
                default:
                    Debug.Log("Error reading ingredient type from JSON");
                    return BaseItem.undefinedItem;
            }
        }
        Debug.Log("Error reading ingredient type from JSON");
        return BaseItem.undefinedItem;
    }
}

