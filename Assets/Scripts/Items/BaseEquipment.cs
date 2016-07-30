using UnityEngine;
using System.Collections;
using System;

public enum SlotType { HEAD, BODY, LEGS, GLOVES, BOOTS, BACK, MAIN_HAND, OFF_HAND, TWO_HAND };

[Serializable]
public class BaseEquipment : BaseItem
{
    public SlotType slotType = SlotType.MAIN_HAND;
    public float damage = 0;
    public float speed = 0;
}
