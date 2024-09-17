using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler  
{
    [Header("Item Data")]
    public string itemName;
    public int amount;
    [SerializeField]private Sprite itemSprite;
    public bool isInvFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField]private int maxNumberOfItems;
    
    [Header("Item Slot")]
    [SerializeField] private TextMeshProUGUI amountText;

    [SerializeField] private Image itemImage;

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

    public int AddItem(string itemName, int itemAmount, Sprite itemSprite, string itemDescription)
    {

        if (isInvFull)
        {
            return amount;
        }
        //Update those
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.itemDescription = itemDescription;
        
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
        //ik verplaats dit om het in een button script te gooien,
        //omdat ik niet wil dat je moet dubbel klikken
        if (isItemSelected)
        {
            bool isUsable =  _inventoryManager.UseItem(itemName);
            if (isUsable)
            {
                this.amount -= 1;
                isInvFull = false;
                amountText.text = this.amount.ToString();
                if (this.amount <= 0)
                {
                    EmplySlot();
                }
            }
        }
        else
        {
            _inventoryManager.DeselectSlots();
            selectedShader.SetActive(true);
            isItemSelected = true;
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;

            if (itemDescriptionImage == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }
        }
    }

    private void EmplySlot()
    {
        amountText.enabled = false;
        itemImage.sprite = emptySprite;
        itemDescription = "";
        itemName = "";
        
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
