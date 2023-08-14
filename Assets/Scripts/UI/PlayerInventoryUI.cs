using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInventoryUI : InventoryUI
{
    [FormerlySerializedAs("headSlot")] public EquipmentSlotUI headSlotUI;
    [FormerlySerializedAs("bodySlot")] public EquipmentSlotUI bodySlotUI;
    [FormerlySerializedAs("legsSlot")] public EquipmentSlotUI legsSlotUI;
    [FormerlySerializedAs("feetSlot")] public EquipmentSlotUI feetSlotUI;
    [FormerlySerializedAs("leftArmSlot")] public EquipmentSlotUI leftArmSlotUI;
    [FormerlySerializedAs("rightArmSlot")] public EquipmentSlotUI rightArmSlotUI;
    
    public PlayerInventory playerInventory;

    
    [SerializeField] private GameObject slotUIPrefab;
    [SerializeField] private Transform slotContainer;
    [SerializeField] private List<InventorySlotUI> slots;

    public Tooltip tooltip;
    public InventorySlotUI currentInventorySlotUI;
    public InventorySlotUI previouslyInventorySlotUI;
    
    private void Start()
    {
        if (playerInventory != null)
        {
            inventory = playerInventory.inventory;

            inventory.onItemAdded.AddListener(AddSlot);
            inventory.onItemRemoved.AddListener(RemoveSlot);
        }
    }

    public void AddSlot(InventorySlot item)
    {
        if (item.itemSO.itemStackable)
        {
            if (slotDictionary.TryGetValue(item, out var slot))
            {
                if (item.stackSize >= item.itemSO.maxStackSize) return;
                
                slot.UpdateUISlot();
            }
            else
            {
                var slotGo = Instantiate(slotUIPrefab, slotContainer);
                slotGo.name = item.itemSO.itemName + "SlotPrefab";
                var newSlot = slotGo.GetComponent<InventorySlotUI>();
                slots.Add(newSlot);
                newSlot.Init(item, this);
                slotDictionary.Add(item, newSlot);
            }
        }
        else
        {
            var slotGo = Instantiate(slotUIPrefab, slotContainer);
            slotGo.name = item.itemSO.itemName + "SlotPrefab";
            var newSlot = slotGo.GetComponent<InventorySlotUI>();
            slots.Add(newSlot);
            newSlot.Init(item, this);
            slotDictionary.Add(item, newSlot);
        }
    }

    public void RemoveSlot(InventorySlot item)
    {
        if (slotDictionary.ContainsKey(item))
        {
            var slot = slotDictionary[item];
            item.stackSize--;
            slot.UpdateUISlot();

            if (item.stackSize >= 1) return;
            
            slotDictionary.Remove(item);
            slots.Remove(slot);
            inventory.RemoveItem(item.itemSO);

            Destroy(slot.gameObject);
            tooltip.gameObject.SetActive(false);
            tooltip.RemoveAllListeners();
        }
    }
}