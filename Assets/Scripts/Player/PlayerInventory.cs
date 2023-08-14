using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public Transform dropPoint;

    public void DropItem(ItemSO itemSO) => Instantiate(itemSO.dropItemPrefab, dropPoint.position, Quaternion.identity);
}