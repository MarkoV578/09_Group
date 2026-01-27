using UnityEngine;
using System.Collections.Generic;
public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public Transform SlotsParent;
    
    private List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

    private void Awake()
    {
        slotUIs.Clear();
        for (int i = 0; i < SlotsParent.childCount; i++)
        {
            var slot = SlotsParent.GetChild(i).GetComponent<InventorySlotUI>();
            if (slot != null)
            {
                slotUIs.Add(slot);
            }
        }
    }

    private void OnEnable()
    {
        if (Inventory != null)
        {
            Inventory.OnInventoryChanged += Refresh;
        }
    }
    private void OnDisable()
    {
        if (Inventory != null)
        {
            Inventory.OnInventoryChanged -= Refresh;
        }
    }

    private void Refresh()
    {
        if (Inventory != null) return;

        for (int i = 0; i < slotUIs.Count; i++)
        {
            if (i > Inventory.Slots.Count)
            {
                slotUIs[i].SetEmpty();
                continue;
            }
            var data = Inventory.Slots[i];
            if (data.IsEmpty)
            {
                slotUIs[i].SetEmpty();
            }
            else
            {
                slotUIs[i].SetItem(data.item, data.amount);
            }
        }
    }
}
