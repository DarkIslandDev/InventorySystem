using UnityEngine.Serialization;

[System.Serializable]
public class InventorySlot
{
    public ItemSO itemSO;
    public int stackSize;

    public InventorySlot(ItemSO source, int amount)
    {
        itemSO = source;
        stackSize = amount;
    }

    public InventorySlot()
    {
        ClearSlot();
    }

    public void ClearSlot()
    {
        itemSO = null;
        stackSize = 0;
    }

    public void UpdateInventorySlot(ItemSO data, int amount)
    {
        itemSO = data;
        stackSize = amount;
    }

    public void AddToStack(int amount) => stackSize += amount;

    public void RemoveFromStack(int amount) => stackSize -= amount;
}