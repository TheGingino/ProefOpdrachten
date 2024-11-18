using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI1 : MonoBehaviour
{
    public Button sortByNameButton;
    public Button sortByStatButton;
    [SerializeField] private Button[] itemDecision;
    public InventoryManager inventoryManager;

    private void Start()
    {
        // Hook up button click events to sorting methods
        sortByNameButton.onClick.AddListener(inventoryManager.SortInventoryByName);
        sortByStatButton.onClick.AddListener(inventoryManager.SortInventoryByStat);
    }
}
