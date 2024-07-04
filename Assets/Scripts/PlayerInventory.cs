using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<InventoryItem> items = new ();

    public void AddItem(Item item, int quantity, int sellPrice)
    {
        InventoryItem inventoryItem = items.Find(i => i.item == item);
        if (inventoryItem != null)
        {
            inventoryItem.quantity += quantity;
            inventoryItem.sellPrice = sellPrice;
        }
        else
        {
            items.Add(new InventoryItem(item, quantity, sellPrice));
        }
    }

    public void RemoveItem(Item item, int quantity)
    {
        InventoryItem inventoryItem = items.Find(i => i.item == item);
        if (inventoryItem != null)
        {
            inventoryItem.quantity -= quantity;
            if (inventoryItem.quantity <= 0)
            {
                items.Remove(inventoryItem);
            }
        }
    }

    public InventoryItem GetInventoryItem(Item item)
    {
        return items.Find(i => i.item == item);
    }
}
