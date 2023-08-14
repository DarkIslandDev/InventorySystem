using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private Button button;
    [SerializeField] private Tooltip tooltip;
    
    public InventorySlot assignedInventorySlot;
    public PlayerInventoryUI inventoryUI;

    private void Awake()
    {
        button.onClick.AddListener(OnUISlotClick);
    }

    public void Init(InventorySlot slot, PlayerInventoryUI inventory)
    {
        assignedInventorySlot = slot;
        inventoryUI = inventory;
        UpdateUISlot(slot);
    }

    private void UpdateUISlot(InventorySlot slot)
    {
        if (slot.itemSO != null)
        {
            itemSprite.sprite = slot.itemSO.itemIcon;
            itemSprite.color = Color.white;

            itemCount.text = slot.stackSize > 1 ? slot.stackSize.ToString() : string.Empty;
        }
        else
        {
            ClearSlot();
        }
    }

    public void UpdateUISlot()
    {
        if(assignedInventorySlot != null) UpdateUISlot(assignedInventorySlot);
    }
    
    private void ClearSlot()
    {
        assignedInventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = string.Empty;
    }

    private void OnUISlotClick()
    {
        inventoryUI.currentInventorySlotUI = this;
        
        tooltip = inventoryUI.tooltip;
        
        tooltip.RemoveAllListeners();

        tooltip.useButton.onClick.AddListener(UseItemOnClick);
        tooltip.dropButton.onClick.AddListener(DropItemOnClick);
        tooltip.cancelButton.onClick.AddListener(CancelTooltipOnClick);
        
        if (inventoryUI.previouslyInventorySlotUI == null) inventoryUI.previouslyInventorySlotUI = inventoryUI.currentInventorySlotUI;;
        
        if (inventoryUI.previouslyInventorySlotUI == this) inventoryUI.previouslyInventorySlotUI.tooltip.gameObject.SetActive(false);

        tooltip.gameObject.SetActive(true);
        tooltip.TooltipPosition(transform.position);
        
        inventoryUI.previouslyInventorySlotUI = this;
        
        

    }

    private void UseItemOnClick()
    {
        switch (assignedInventorySlot.itemSO.itemType)
        {
            case ItemType.Equipment:
                EquipItem();
                break;
            case ItemType.Food:
                UseItem();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        inventoryUI.RemoveSlot(assignedInventorySlot);
    }

    private void EquipItem()
    {
        var equipmentItemSO = assignedInventorySlot.itemSO as EquipmentItemSo;

        if (equipmentItemSO != null)
            switch (equipmentItemSO.equipmentType)
            {
                case EquipmentType.Head:
                    inventoryUI.headSlotUI.InitSlot(equipmentItemSO);
                    break;
                case EquipmentType.Body:
                    inventoryUI.bodySlotUI.InitSlot(equipmentItemSO);
                    break;
                case EquipmentType.Legs:
                    inventoryUI.legsSlotUI.InitSlot(equipmentItemSO);
                    break;
                case EquipmentType.Feet:
                    inventoryUI.feetSlotUI.InitSlot(equipmentItemSO);
                    break;
                case EquipmentType.LeftArm:
                    inventoryUI.leftArmSlotUI.InitSlot(equipmentItemSO);
                    break;
                case EquipmentType.RightArm:
                    inventoryUI.rightArmSlotUI.InitSlot(equipmentItemSO);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
    }

    private void UseItem()
    {
        var usableItem = assignedInventorySlot.itemSO as UsableItemSO;

        if (usableItem != null) usableItem.Use(inventoryUI.playerInventory.inventory);
    }

    private void DropItemOnClick()
    {
        inventoryUI.RemoveSlot(assignedInventorySlot);
        inventoryUI.playerInventory.DropItem(assignedInventorySlot.itemSO);
    }
    
    private void CancelTooltipOnClick()
    {
        tooltip.gameObject.SetActive(false);
    }
}