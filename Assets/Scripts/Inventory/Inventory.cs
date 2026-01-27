using UnityEngine;
using System;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int Capacity = 15;

    public List<InventorySlotData> Slots;
    public Action OnInventoryChanged;

    private void Awake()
    {
        Slots = new List<InventorySlotData>(Capacity);
        for (int i = 0; i < Capacity; i++)
        {
            Slots.Add(new InventorySlotData());
        }
    }

    public bool AddItem(ItemSO item, int amount = 1)
    { 
        if(item == null || amount <= 0) return false;
        if (item.isStackable)
        {
            for (int i = 0; i < Slots.Count; i++)
            {
                var slot = Slots[i];
                if(!slot.IsEmpty && slot.item == item && slot.amount < item.maxStack)
                {
                    int canAdd = item.maxStack - slot.amount;
                    int toAdd = Mathf.Min(canAdd, amount);
                    slot.amount += toAdd;
                    amount -= toAdd;
                    if (amount <= 0)
                    {
                        OnInventoryChanged?.Invoke();
                        return true;
                    }
                    
                }
            }
        }

        for (int i = 0; i < Slots.Count; i++)
        {
            var slot = Slots[i];
            if (slot.IsEmpty)
            {
                slot.item = item;
                slot.amount = amount;

                if (item.isStackable && slot.amount > item.maxStack)
                {
                    int leftover = slot.amount - item.maxStack;
                    slot.amount = item.maxStack;
                    
                    OnInventoryChanged?.Invoke();
                    return AddItem(item, leftover);
                }
                OnInventoryChanged.Invoke();
                return true;
                
            }
        }
        return false; 
    }
    
}
