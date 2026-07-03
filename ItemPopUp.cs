using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPopUp : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Image previewImage;
    public Button confirmButton;
    public Button cancelButton;
    public Button goBackButton;
    public Button detailsButton;
    public GameObject detailsPanel;
    public TextMeshProUGUI detailsTextA;
    public TextMeshProUGUI detailsTextB;

    private MaterialObject pendingItem;
    private CoinManager coinManager;

    void Awake()
    {
        coinManager = Object.FindFirstObjectByType<CoinManager>();
    }

    public void OpenPopup(MaterialObject item)
    {
        pendingItem = item;
        itemName.text = $"Buy {item.materialName} for {item.price} coins?";
        previewImage.sprite = item.icon;

        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
        detailsButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(ExecutePurchase);
        cancelButton.onClick.AddListener(ClosePopup);
        detailsButton.onClick.AddListener(OpenDetails);
        gameObject.SetActive(true);
    }

    private void ExecutePurchase()
    {
        if (coinManager != null && pendingItem != null)
        {
            coinManager.BuyItem(pendingItem.price);
            MaterialManager.Instance.currentMaterial = pendingItem;
            PlayerPrefs.SetInt("CurrentMaterial", pendingItem.order);
        }
        ClosePopup();
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }

    public void OpenDetails()
    {
        detailsTextA.text = pendingItem.fatigueStrengthCoeff.ToString();
        detailsTextA.text = pendingItem.fatigueSrengthExp.ToString();
        goBackButton.onClick.RemoveAllListeners();
        goBackButton.onClick.AddListener(CloseDetails);
        detailsPanel.SetActive(true);
    }

    public void CloseDetails()
    {
        detailsPanel.SetActive(false);
    }
}