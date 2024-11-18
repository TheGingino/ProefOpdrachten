using UnityEngine;
using UnityEngine.UIElements;

public class Item : MonoBehaviour
{
    public ItemSO itemData;  // Het ScriptableObject voor dit specifieke item
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
            int leftOverItems = inventoryManager.AddItem(itemData, amount);  // Voeg het item toe aan de inventaris
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);  // Verwijder het item uit de wereld als alles is toegevoegd
            }
            else
            {
                amount = leftOverItems;  // Anders wordt de hoeveelheid bijgewerkt
                Destroy(gameObject);
            }
        }
    }
}