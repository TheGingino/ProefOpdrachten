using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public ItemSlot[] itemSlot;


    public void AddItem(string itemName, int amount, Sprite sprite)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isInvFull)
            {
                itemSlot[i].AddItem(itemName,amount,sprite);
                return;
            }
        }
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
