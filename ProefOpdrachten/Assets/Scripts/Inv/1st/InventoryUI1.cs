using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI1 : MonoBehaviour
{
    public Button sortByNameButton;
    public Button sortByStatButton;
    public Button sortOpen, sortClose ;
    [SerializeField] private Button[] itemDecision;
    public InventoryManager inventoryManager;

    [SerializeField] private GameObject sortButtons, sortButton;
    private bool isSortOpen;

    private void Start()
    {
        isSortOpen = false;
        sortByNameButton.onClick.AddListener(inventoryManager.SortInventoryByName);
        sortByStatButton.onClick.AddListener(inventoryManager.SortInventoryByStat);
        
        sortOpen.onClick.AddListener(OpenSortButtons);
        sortClose.onClick.AddListener(CloseSortButtons);
    }
    
    private void OpenSortButtons()
    {
        isSortOpen = true;
        sortButton.SetActive(false);
        sortButtons.SetActive(true);
    }

    private void CloseSortButtons()
    {
        isSortOpen = false;
        sortButton.SetActive(true);
        sortButtons.SetActive(false);
    }
}
