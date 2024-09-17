using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;

    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool isUsable = itemSOs[i].Useitem();
                Debug.Log("Hier gebeurt iets");
                return isUsable;
            }
        }
        return false;
    }
    
    public int AddItem(string itemName, int amount, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isInvFull && itemSlot[i].itemName == itemName || itemSlot[i].amount == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName,amount,itemSprite, itemDescription);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }
                return leftOverItems;
            }
        }
        return amount;
    }

    public void DeselectSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].isItemSelected = false;
        }
    }
    
}
