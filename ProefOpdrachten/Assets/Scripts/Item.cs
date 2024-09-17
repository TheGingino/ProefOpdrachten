using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;
    [SerializeField] private int amount;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventoryManager.AddItem(name, amount, sprite);
            Destroy(gameObject);
        }
    }
}
