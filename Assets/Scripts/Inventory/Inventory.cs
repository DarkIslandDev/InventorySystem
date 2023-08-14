using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory
{
    public List<InventorySlot> inventorySlots;

    public UnityEvent<InventorySlot> onItemAdded;
    public UnityEvent<InventorySlot> onItemRemoved;

    public void AddItem(ItemSO usableItem, int amountToAdd)
    {
        var existingItem = inventorySlots.Find(inventorySlot => inventorySlot.itemSO == usableItem);

        if (existingItem != null && existingItem.itemSO.itemStackable)
        {
            if (existingItem.stackSize >= existingItem.itemSO.maxStackSize)
            {
                var newItem = new InventorySlot(usableItem, amountToAdd);
                inventorySlots.Add(newItem);
                onItemAdded?.Invoke(newItem);
            }
            else
            {
                existingItem.AddToStack(amountToAdd);

                onItemAdded?.Invoke(existingItem);
            }
        }
        else
        {
            var newItem = new InventorySlot(usableItem, amountToAdd);
            inventorySlots.Add(newItem);
            onItemAdded?.Invoke(newItem);
        }
    }

    public void RemoveItem(ItemSO usableItem)
    {
        var existingItem = inventorySlots.Find(inventorySlot => inventorySlot.itemSO == usableItem);

        if (existingItem == null) return;
        
        switch (existingItem.stackSize)
        {
            case >= 1:
                existingItem.stackSize--;
                break;
            case < 1:
                inventorySlots.Remove(existingItem);
                break;
        }
        
        onItemRemoved?.Invoke(existingItem);
    }
}