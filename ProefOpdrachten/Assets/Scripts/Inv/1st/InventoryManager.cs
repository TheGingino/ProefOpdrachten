using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot[] itemSlots; 

    public bool UseItem(ItemSO itemSO) 
    {
        if (itemSO != null)
        {
            return itemSO.UseItem();
        }
        else
        {
            DeselectSlots();
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
                    return AddItem(itemSO, leftOverItems); 
                }
                return 0;
            }
        }
        return amount; 
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
        List<ItemSlot> sortedSlots = new List<ItemSlot>(itemSlots);
        sortedSlots.Sort((slot1, slot2) =>
        {
            if (slot1.currentItem == null) return 1;
            if (slot2.currentItem == null) return -1;
            return slot1.currentItem.itemName.CompareTo(slot2.currentItem.itemName);
        });
        
        UpdateInventoryUI(sortedSlots);
    }

    public void SortInventoryByStat()
    {
        List<ItemSlot> sortedSlots = new List<ItemSlot>(itemSlots);
        sortedSlots.Sort((slot1, slot2) =>
        {
            if (slot1.currentItem == null) return 1;
            if (slot2.currentItem == null) return -1;
            return slot1.currentItem.statToChange.CompareTo(slot2.currentItem.statToChange);
        });

        UpdateInventoryUI(sortedSlots);
    }

    private void UpdateInventoryUI(List<ItemSlot> sortedSlots)
    {
        for (int i = 0; i < sortedSlots.Count; i++)
        {
            if (sortedSlots[i].currentItem != null)
            {
                itemSlots[i].itemImage.sprite = sortedSlots[i].currentItem.itemSprite;
                itemSlots[i].amountText.text = sortedSlots[i].amount.ToString();
                itemSlots[i].amountText.enabled = true;
                itemSlots[i].itemDescriptionNameText = sortedSlots[i].itemDescriptionNameText;
                itemSlots[i].itemDescriptionText = sortedSlots[i].itemDescriptionText;
                itemSlots[i].itemDescriptionImage = sortedSlots[i].itemDescriptionImage;

            }
            else
            {
                itemSlots[i].itemImage.sprite = itemSlots[i].emptySprite;
                itemSlots[i].amountText.enabled = false;
                
                itemSlots[i].itemDescriptionNameText.text = string.Empty;
                itemSlots[i].itemDescriptionText.text = string.Empty;
                itemSlots[i].itemDescriptionImage.sprite = null;
            }
        }
    }
}