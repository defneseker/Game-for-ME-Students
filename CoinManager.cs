using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class CoinManager : MonoBehaviour
{
    [Header ("UI Reference")]
    public TextMeshProUGUI coinText;

    [Header("Coin Data")]
    private int currentCoins = 0;

    void Start()
    {
        currentCoins = PlayerPrefs.GetInt("TotalCoins", 150);
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        PlayerPrefs.SetInt("TotalCoins", currentCoins);
        UpdateCoinText();
    }

    public void RemoveCoins(int amount)
    {
        if (currentCoins >= amount)
        {
            currentCoins -= amount;
            PlayerPrefs.SetInt("TotalCoins", currentCoins);
            UpdateCoinText();
        }
    }

    public bool CanAfford(int amount)
    {
        return currentCoins >= amount;
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = currentCoins.ToString();
        }
    }

    public void BuyItem(int price)
    {
        if (CanAfford(price))
        {
            RemoveCoins(price);
            Debug.Log("Item purchased for " + price + " coins");
        }
        else
        {
            Debug.Log("Not enough coins to purchase item");
        }
    }

    public void BackToMap()
    {
        SceneManager.LoadScene("Map");
    }
}
