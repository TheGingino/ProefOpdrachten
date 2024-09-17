using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler  
{
    public string itemName;
    [SerializeField]private int amount;
    [SerializeField]private Sprite sprite;
    public bool isInvFull;

    [SerializeField] private TextMeshProUGUI amountText;

    [SerializeField] private Image itemImage;

    public GameObject selectedShader;

    public bool isItemSelected;

    private InventoryManager _inventoryManager;


    private void Start()
    {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, int itemAmount, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.sprite = itemSprite;
        this.amount = itemAmount;
        isInvFull = true;

        amountText.text = amount.ToString();
        amountText.enabled = true;
        itemImage.sprite = sprite;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    private void OnLeftClick()
    {
        _inventoryManager.DeselectSlots();
        selectedShader.SetActive(true);
        isItemSelected = true;
    }
    private void OnRightClick()
    {
        selectedShader.SetActive(false);
        isItemSelected = false;
    }
    
}
