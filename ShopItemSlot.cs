using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlot : MonoBehaviour
{
    [Header("Item Data")]
    public MaterialObject itemData; 

    [Header("UI Component References")]
    public Image buttonIconImage;        
    public ItemPopUp popupWindow;       
    public GameObject defaultPanel;
    public GameObject lowerMatPanel;
    public GameObject detailsPanel;
    public Button closeDefault;
    public Button closeLowerMat;
    public Button defaultDetails;
    

    void Start()
    {
        DisplayItemSprite();
    }

    public void DisplayItemSprite()
    {
        if (itemData != null && buttonIconImage != null)
        {
            buttonIconImage.sprite = itemData.icon;
        }
    }

    public void OnSlotClicked()
    {
        int currentOrder = PlayerPrefs.GetInt("CurrentMaterial");
        if (itemData != null && popupWindow != null)
        {
            if (itemData.order == 0 && currentOrder == 0)
            {
                closeDefault.onClick.RemoveAllListeners();
                defaultDetails.onClick.RemoveAllListeners();
                closeDefault.onClick.AddListener(CloseDefault);
                defaultDetails.onClick.AddListener(OpenDefaultDetails);
                defaultPanel.SetActive(true);
            }
            else if (itemData.order < currentOrder)
            {
                closeLowerMat.onClick.RemoveAllListeners();
                closeLowerMat.onClick.AddListener(CloseLowerMat);
                lowerMatPanel.SetActive(true);
            }
            else
            {
                popupWindow.OpenPopup(itemData);
            }
            
        }
    }

    public void CloseDefault()
    {
        defaultPanel.SetActive(false);
    }

    public void CloseLowerMat()
    {
        lowerMatPanel.SetActive(false);
    }

    public void OpenDefaultDetails()
    {
        detailsPanel.SetActive(true);
    }
}