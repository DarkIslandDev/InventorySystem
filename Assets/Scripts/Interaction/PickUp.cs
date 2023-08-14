using UnityEngine;

public class PickUp : Interaction
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private int itemAmount = 1;

    public override bool Interact(Player player, PlayerInteraction playerInteraction)
    {
        if (itemSO != null)
        {
            PickUpItem(player);
        }
        
        return base.Interact(player, playerInteraction);
    }

    private void PickUpItem(Player player)
    {
        player.playerInventory.inventory.AddItem(itemSO, itemAmount);
        Destroy(gameObject);
    }
}