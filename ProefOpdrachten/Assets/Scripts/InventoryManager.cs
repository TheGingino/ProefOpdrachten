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
}