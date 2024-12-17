using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Item Data")]
    public ItemSO currentItem; 
    public int amount;  
    public bool isInvFull;
    public Sprite emptySprite;

    [SerializeField] private int maxNumberOfItems;

    [Header("Item Slot")]
    public TextMeshProUGUI amountText;
    public Image itemImage;

    [Header("Item Description")]
    public Image itemDescriptionImage;
    public TextMeshProUGUI itemDescriptionNameText;
    public TextMeshProUGUI itemDescriptionText;

    public GameObject selectedShader;
    public bool isItemSelected;

    private InventoryManager _inventoryManager;

    private void Start()
    {
        _inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(ItemSO itemSO, int itemAmount)
    {
        if (isInvFull)
        {
            return amount;
        }

        this.currentItem = itemSO;
        itemImage.sprite = itemSO.itemSprite;
        this.amount += itemAmount;

        if (this.amount >= maxNumberOfItems)
        {
            amountText.text = maxNumberOfItems.ToString();
            amountText.enabled = true;
            isInvFull = true;

            int extraItems = this.amount - maxNumberOfItems;
            this.amount = maxNumberOfItems;
            return extraItems;
        }

        amountText.text = this.amount.ToString();
        amountText.enabled = true;
        return 0;
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
        if (currentItem == null)
        {
            Debug.Log("Geen item in dit slot.");
            return;  
        }

        if (isItemSelected)
        {
            bool isUsable = _inventoryManager.UseItem(currentItem); 
            if (isUsable)
            {
                this.amount -= 1;
                isInvFull = false;
                amountText.text = this.amount.ToString();
                if (this.amount <= 0)
                {
                    EmptySlot();
                }
            }
        }
        else
        {
            _inventoryManager.DeselectSlots();
            selectedShader.SetActive(true);
            isItemSelected = true;

            itemDescriptionNameText.text = currentItem.itemName;
            itemDescriptionText.text = currentItem.itemDescription;
            itemDescriptionImage.sprite = currentItem.itemSprite;
        }
    }

    private void EmptySlot()
    {
        amountText.enabled = false;
        itemImage.sprite = emptySprite;
        currentItem = null;

        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }

    private void OnRightClick()
    {
        selectedShader.SetActive(false);
        isItemSelected = false;
    }
}