using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : MonoBehaviour
{
    [Header("Item Data")]
    public ShopItem itemData; 

    [Header("UI Component References")]
    public Image buttonIconImage;        
    public ItemPopUp popupWindow;       

    void Start()
    {
        DisplayItemSprite();
    }

    public void DisplayItemSprite()
    {
        if (itemData != null && buttonIconImage != null)
        {
            buttonIconImage.sprite = itemData.itemIcon;
        }
    }

    public void OnSlotClicked()
    {
        if (itemData != null && popupWindow != null)
        {
            popupWindow.OpenPopup(itemData);
        }
    }
}