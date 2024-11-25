using UnityEngine;
using UnityEngine.Events;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private UnityEvent openEvent;
    bool isInvOpen = true;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInvOpen)
            {
                TurnOn();
                isInvOpen = true;
            }
            else
            {
                TurnOff();
                isInvOpen = false;
            }
        }
    }


    private void TurnOn()
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0f;

    }
    private void TurnOff()
    {
        inventoryUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
