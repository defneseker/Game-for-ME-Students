using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPopUp : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Image previewImage;
    public Button confirmButton;
    public Button cancelButton;

    private ShopItem pendingItem;
    private CoinManager coinManager;

    void Awake()
    {
        coinManager = Object.FindFirstObjectByType<CoinManager>();
    }

    public void OpenPopup(ShopItem item)
    {
        pendingItem = item;
        itemName.text = $"Buy {item.itemName} for {item.itemCost} coins?";
        previewImage.sprite = item.itemIcon;

        confirmButton.onClick.RemoveAllListeners();
        cancelButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(ExecutePurchase);
        cancelButton.onClick.AddListener(ClosePopup);
        gameObject.SetActive(true);
    }

    private void ExecutePurchase()
    {
        if (coinManager != null && pendingItem != null)
        {
            coinManager.BuyItem(pendingItem.itemCost);
        }
        ClosePopup();
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}