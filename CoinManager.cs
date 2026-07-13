using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [Header ("UI Reference")]
    public TextMeshProUGUI coinText;
    public GameObject CanBuyPanel;
    public GameObject CannotBuyPanel;


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
            CanBuyPanel.SetActive(true);
        }
        else
        {
            CannotBuyPanel.SetActive(true);
        }
    }

    public void BackToMap()
    {
        SceneManager.LoadScene("Map");
    }

    public int GetCoins()
    {
        return PlayerPrefs.GetInt("TotalCoins");
    }

}
