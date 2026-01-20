using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Inventory/ItemSO")]
public class ItemSO : ScriptableObject
{
    public Texture Icon;
    public int Cost = 1;
    public string ItemName;
    
    [Header("Stack settings")]
    public bool isStackable =  true;
    public int maxStack = 99;   
}
