using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    public ItemSO itemData;  
    public int amount = 1;
    public Sprite icon;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int leftOverItems = inventoryManager.AddItem(itemData, amount);  
            if (leftOverItems <= 0)
            {
                Destroy(gameObject); 
            }
            else
            {
                amount = leftOverItems;  
                Destroy(gameObject);
            }
        }
    }
}