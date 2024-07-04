using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class InventoryItem
{

    public Item item; // Reference to the Item ScriptableObject
    public int quantity;
    public int sellPrice; // Dynamic sell price

    public InventoryItem(Item item, int quantity, int sellPrice)
    {
        this.item = item;
        this.quantity = quantity;
        this.sellPrice = sellPrice;
    }
}