using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject uiInventory;

    public void InventoryUI()
    {
        uiInventory.SetActive(!uiInventory.activeSelf);
    }
}