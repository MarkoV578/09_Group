using UnityEngine;

public class PlayerPickUpInterector : MonoBehaviour
{
    public Inventory inventory;
    private PickUpItem currentPickUpItem;

    void Update()
    {
        if (currentPickUpItem != null) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentPickUpItem.TryToPickUp(inventory);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PickUpItem>(out PickUpItem pickUp))
        {
            currentPickUpItem = pickUp;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PickUpItem>(out PickUpItem pickUp))
        {
            if (currentPickUpItem = pickUp)
            {
                currentPickUpItem = null;
            }
        }
    }
}
