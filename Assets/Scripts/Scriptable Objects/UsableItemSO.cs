using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Usable Item", fileName = "Usable item")]
public class UsableItemSO : ItemSO
{
    public List<ItemEffect> effects;

    public void Use(Inventory inventory)
    {
        foreach (var effect in effects)
        {
            effect.ExecuteEffect(this, inventory);
        }
    }
}