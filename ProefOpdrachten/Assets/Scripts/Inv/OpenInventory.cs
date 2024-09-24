using UnityEngine;
using UnityEngine.Events;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    public UnityEvent openEvent;
    bool isInvOpen = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isInvOpen)
            {
                openEvent.Invoke();
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
