using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Item Data")]
    public ItemSO currentItem; // Gebruik het ItemSO
    public int amount;  // Aantal items in het slot
    public bool isInvFull;
    public Sprite emptySprite;

    [SerializeField] private int maxNumberOfItems;

    [Header("Item Slot")]
    [SerializeField]
    public TextMeshProUGUI amountText;
    [SerializeField] public Image itemImage;

    [Header("Item Description")]
    [SerializeField] private Image itemDescriptionImage;
    [SerializeField] private TextMeshProUGUI itemDescriptionNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

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

        // Update het item slot met ItemSO gegevens
        this.currentItem = itemSO;
        itemImage.sprite = itemSO.itemSprite;
        this.amount += itemAmount;

        // Update de hoeveelheid
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
        // Check of er een item aanwezig is
        if (currentItem == null)
        {
            Debug.Log("Geen item in dit slot.");
            return;  // Geen item om mee te werken
        }

        if (isItemSelected)
        {
            bool isUsable = _inventoryManager.UseItem(currentItem); // Gebruik het item op basis van ItemSO
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

            // Update de item beschrijving UI
            itemDescriptionNameText.text = currentItem.itemName;
            itemDescriptionText.text = currentItem.itemDescription;
            itemDescriptionImage.sprite = currentItem.itemSprite;
        }
    }

    private void EmptySlot()
    {
        // Reset het slot naar een lege staat
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