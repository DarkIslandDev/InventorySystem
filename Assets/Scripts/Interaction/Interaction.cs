using UnityEngine;

public class Interaction : MonoBehaviour, IPlayerInteraction
{
    public virtual bool Interact(Player player, PlayerInteraction playerInteraction)
    {
        return true;
    }
}