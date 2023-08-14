using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item effect", fileName = "Item effect")]
public class ItemEffect : ScriptableObject
{
    public void ExecuteEffect(UsableItemSO parentItem, Inventory inventory)
    {
        Debug.Log($"Used: {name}");
    }
}