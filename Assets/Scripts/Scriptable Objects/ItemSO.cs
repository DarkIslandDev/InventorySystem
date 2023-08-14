using UnityEngine;

public enum ItemType
{
    Food,
    Equipment
}
public class ItemSO : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    [TextArea(4,4)] public string itemDescription;
    public int maxStackSize;
    public bool itemStackable;
    public ItemType itemType;
    public GameObject itemPrefab;
    public GameObject dropItemPrefab;
}