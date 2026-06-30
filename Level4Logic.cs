using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class Level4Finish : MonoBehaviour
{
    public TMP_InputField no1;
    public TMP_InputField no2;
    public TMP_InputField no3;
    public TextMeshProUGUI pts;
    public Button proceedButton;
    public Button submitButton;
    
    public void CheckAnswer()
    {
        float val1 = ConvertToFloat(no1.text);
        float val2 = ConvertToFloat(no2.text);
        float val3 = ConvertToFloat(no3.text);
        float finalResult = val1 + val2 + val3;
        if (finalResult > 21)
        {
            SceneManager.LoadScene("LevelFail");
            return;
        }
        if (finalResult < 10)
        {
            pts.text = "POINTS: 5"; 
        }
        else if (10 <= finalResult && finalResult < 18)
        {
            pts.text = "POINTS: 10";
        }
        else if (18 <= finalResult && finalResult <= 21)
        {
            pts.text = "POINTS: 15";
        }
    }

    private float ConvertToFloat(string text)
    {
        if (string.IsNullOrEmpty(text)) return 0f;
        string cleanedText = text.Trim(); 

        if (float.TryParse(cleanedText, out float result))
        {
            return result;
        }
        return 0f;
    }

    public int GetCurrentLevelNumber()
    {
        // 1. Get the actual text name of the active scene (e.g., "Level15")
        string sceneName = SceneManager.GetActiveScene().name;

        // 2. Use Regex to strip away everything except the numbers
        string numberOnly = Regex.Match(sceneName, @"\d+").Value;

        // 3. Convert that string number into an actual usable integer
        if (int.TryParse(numberOnly, out int levelNumber))
        {
            return levelNumber; 
        }
        return 0; 
    }

    int currentLevel;
    void Start()
    {
        currentLevel = GetCurrentLevelNumber();
        PlayerPrefs.SetInt("PreviousSceneIndex", currentLevel);
        PlayerPrefs.Save();
        proceedButton.gameObject.SetActive(false);
        pts.gameObject.SetActive(false);
    }

    public void Proceed()
    {
        SceneManager.LoadScene("LevelSuccess");
        PlayerPrefs.SetInt("ReachedLevel", currentLevel + 1);
    }

    public void DisplayResult()
    {
        submitButton.interactable = false;
        CheckAnswer();
        pts.gameObject.SetActive(true);
        proceedButton.gameObject.SetActive(true);
    }
}

