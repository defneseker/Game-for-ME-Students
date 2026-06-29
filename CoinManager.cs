using UnityEngine;
using TMPro;

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
}
