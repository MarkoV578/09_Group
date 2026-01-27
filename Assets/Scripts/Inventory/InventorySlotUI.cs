using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class InventorySlotUI : MonoBehaviour
{
    public GameObject itemViewObject;
    [FormerlySerializedAs("itemImage")] public RawImage itemIcon;
    public TMP_Text itemName;
    public TMP_Text AmountText;

    public void SetEmpty()
    {
        if (itemViewObject != null)
        {
            itemViewObject.SetActive(false);
        }
        if (AmountText != null)
        {
            AmountText.text = "";
        }
    }

    public void SetItem(ItemSO item, int amount)
    {
        if (itemViewObject != null)
        {
            itemViewObject.SetActive(true);
        }

        if (itemIcon != null)
        {
            itemIcon.texture = item.Icon;
        }

        if (AmountText != null)
        {
            if (item != null && item.isStackable && amount > 1)
            {
                AmountText.text = amount.ToString();
            }
            else
            {
                AmountText.text = "";
            }
        }
    }

}
