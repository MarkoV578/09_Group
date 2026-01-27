using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public ItemSO item;
    public int amount = 1;

    public bool TryToPickUp(Inventory inventory)
    {
        if (inventory == null || item == null) return false;
        bool added = inventory.AddItem(item, amount);
        if (added)
        {
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
