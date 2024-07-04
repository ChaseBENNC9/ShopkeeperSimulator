using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{

    public GameObject inventoryPanel; // Panel to hold inventory items
    public GameObject inventoryItemPrefab; // Prefab for displaying an item in the inventory
    public PlayerInventory playerInventory; // Reference to the player's inventory
    public int maxSlots = 20; // Maximum number of slots in the inventory

    void Start()
    {
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // Clear existing UI items
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Display current items in the inventory
        foreach (var inventoryItem in playerInventory.items)
        {
            GameObject newItem = Instantiate(inventoryItemPrefab, inventoryPanel.transform);
            newItem.transform.Find("ItemName").GetComponent<TextMeshProUGUI>().text = inventoryItem.item.itemName;
            newItem.transform.Find("ItemQuantity").GetComponent<TextMeshProUGUI>().text = inventoryItem.quantity.ToString();
            newItem.transform.Find("ItemIcon").GetComponent<Image>().sprite = inventoryItem.item.icon;
            newItem.transform.Find("ItemSellPrice").GetComponent<TextMeshProUGUI>().text = inventoryItem.sellPrice.ToString();
        }

        // Fill the rest of the slots with empty slot placeholders

    }
}
