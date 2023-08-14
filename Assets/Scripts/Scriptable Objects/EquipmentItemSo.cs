using UnityEngine;

public enum EquipmentType
{
    Head,
    Body,
    Legs,
    Feet,
    LeftArm,
    RightArm
}

[CreateAssetMenu(menuName = "Inventory/Equipment", fileName = "Equipment Item")]
public class EquipmentItemSo : ItemSO
{
    public EquipmentType equipmentType;
}