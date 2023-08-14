using UnityEngine;
using UnityEngine.UI;

public enum EquipmentSlotType
{
    Head,
    Body,
    Legs,
    Feet,
    LeftArm,
    RightArm
}

public class EquipmentSlotUI : MonoBehaviour
{
    [SerializeField] private Image equipmentIcon;
    [SerializeField] private Button button;
    
    public EquipmentSlotType equipmentSlotType;
    public EquipmentItemSo item;
    public PlayerInventoryUI inventoryUI;
    public Transform equipmentTransform;
    private GameObject equipmentItem;
    
    private void Awake()
    {
        button.onClick.AddListener(RemoveSlot);
    }

    public void InitSlot(EquipmentItemSo newItem)
    {
        if (item != null) RemoveSlot();
        
        item = newItem;
        
        equipmentIcon.sprite = item.itemIcon;
        equipmentIcon.color = Color.white;
        equipmentIcon.enabled = true;

        equipmentItem = Instantiate(item.itemPrefab, equipmentTransform);
        equipmentItem.transform.SetParent(equipmentTransform);
    }

    private void RemoveSlot()
    {
        if(item == null) return;

        inventoryUI.playerInventory.inventory.AddItem(item,1);
        
        equipmentIcon.sprite = null;
        equipmentIcon.color = Color.clear;
        equipmentIcon.enabled = false;

        
        Destroy(equipmentItem);
        
        item = null;
    }
}