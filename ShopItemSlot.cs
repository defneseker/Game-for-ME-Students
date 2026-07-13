using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject alreadyHerePanel;
    public Button closeDefault;
    public Button closeDefaultDetails;
    public Button closeLowerMat;
    public Button defaultDetails;
    public Button closeAlrHere;
    public Button openDetails;

    public TextMeshProUGUI detailsTextA;
    public TextMeshProUGUI detailsTextB;
    public TextMeshProUGUI detailsTextSe;
    public TextMeshProUGUI detailsTextSut;
    

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
                closeDefaultDetails.onClick.RemoveAllListeners();
                closeDefault.onClick.AddListener(CloseDefault);
                defaultDetails.onClick.AddListener(OpenDetails);
                closeDefaultDetails.onClick.AddListener(CloseDefaultDetails);
                defaultPanel.SetActive(true);
            }
            else if (itemData.order < currentOrder)
            {
                closeLowerMat.onClick.RemoveAllListeners();
                closeLowerMat.onClick.AddListener(CloseLowerMat);
                lowerMatPanel.SetActive(true);
            }
            else if (itemData.order == currentOrder)
            {
                closeAlrHere.onClick.RemoveAllListeners();
                openDetails.onClick.RemoveAllListeners();
                closeAlrHere.onClick.AddListener(CloseAlrHere);
                openDetails.onClick.AddListener(OpenDetails);
                alreadyHerePanel.SetActive(true);
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

    public void CloseDefaultDetails()
    {
        detailsPanel.SetActive(false);
    }

    public void CloseAlrHere()
    {
        alreadyHerePanel.SetActive(false);
    }

    public void OpenDetails()
    {
        detailsTextA.text = itemData.fatigueStrengthCoeff.ToString();
        detailsTextB.text = itemData.fatigueSrengthExp.ToString();
        detailsTextSe.text = itemData.enduranceLimit.ToString();
        detailsTextSut.text = itemData.ultTensileStrength.ToString();
        detailsPanel.SetActive(true);
    }
}