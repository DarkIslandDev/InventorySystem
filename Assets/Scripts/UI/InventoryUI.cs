using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class InventoryUI : MonoBehaviour
{
    protected Inventory inventory;
    protected readonly Dictionary<InventorySlot, InventorySlotUI> slotDictionary = new Dictionary<InventorySlot, InventorySlotUI>();
}