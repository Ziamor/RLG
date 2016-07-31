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
        BaseItem target = Create(objectType, jObject);

        // Populate the object properties
        serializer.Populate(jObject.CreateReader(), target);

        return target;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        BaseItem item = (BaseItem)value;

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
        writer.WriteEndObject();
    }

    protected BaseItem Create(Type objectType, JObject jObject)
    {
        if (jObject["itemType"] != null)
        {
            switch (jObject["itemType"].ToString())
            {
                case "EQUIPMENT":
                    return new BaseEquipment();
                default:
                    Debug.Log("Error reading item type from JSON");
                    return BaseItem.undefinedItem;
            }
        }
        Debug.Log("Error reading item type from JSON");
        return BaseItem.undefinedItem;
    }
}

