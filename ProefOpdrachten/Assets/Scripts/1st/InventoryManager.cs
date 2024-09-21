using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot[] itemSlots; // De verschillende slots in de inventory

    public bool UseItem(ItemSO itemSO) // Nu gebaseerd op ItemSO
    {
        if (itemSO != null)
        {
            return itemSO.UseItem(); // Gebruik het item via het ScriptableObject
        }

        Debug.Log("Er is geen item om te gebruiken.");
        return false;
    }

    public int AddItem(ItemSO itemSO, int amount)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isInvFull && (itemSlots[i].currentItem == null || itemSlots[i].currentItem == itemSO))
            {
                int leftOverItems = itemSlots[i].AddItem(itemSO, amount);
                if (leftOverItems > 0)
                {
                    return AddItem(itemSO, leftOverItems); // Als er teveel zijn, herhaal
                }
                return 0;
            }
        }

        Debug.Log("Inventory is vol!");
        return amount; // Als het niet past, return de niet toegevoegde items
    }

    public void DeselectSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].isItemSelected = false;
        }
    }
    
    public void SortInventoryByName()
    {
        // Sorteer slots op itemName
        List<ItemSlot> sortedSlots = new List<ItemSlot>(itemSlots);
        sortedSlots.Sort((slot1, slot2) =>
        {
            if (slot1.currentItem == null) return 1; // Plaats lege slots onderaan
            if (slot2.currentItem == null) return -1;
            return slot1.currentItem.itemName.CompareTo(slot2.currentItem.itemName);
        });

        // Update de UI na sorteren
        UpdateInventoryUI(sortedSlots);
    }

    // Nieuwe functie om items te sorteren op StatToChange
    public void SortInventoryByStat()
    {
        // Sorteer slots op de stat die het item verandert
        List<ItemSlot> sortedSlots = new List<ItemSlot>(itemSlots);
        sortedSlots.Sort((slot1, slot2) =>
        {
            if (slot1.currentItem == null) return 1;
            if (slot2.currentItem == null) return -1;
            return slot1.currentItem.statToChange.CompareTo(slot2.currentItem.statToChange);
        });

        // Update de UI na sorteren
        UpdateInventoryUI(sortedSlots);
    }

    // Update de UI slots met gesorteerde slots
    private void UpdateInventoryUI(List<ItemSlot> sortedSlots)
    {
        for (int i = 0; i < sortedSlots.Count; i++)
        {
            if (sortedSlots[i].currentItem != null)
            {
                itemSlots[i].itemImage.sprite = sortedSlots[i].currentItem.itemSprite;
                itemSlots[i].amountText.text = sortedSlots[i].amount.ToString();
                itemSlots[i].amountText.enabled = true;
            }
            else
            {
                itemSlots[i].itemImage.sprite = itemSlots[i].emptySprite; // Leeg slot
                itemSlots[i].amountText.enabled = false;
            }
        }
    }
}