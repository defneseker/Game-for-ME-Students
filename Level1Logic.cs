using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Level1Finish : MonoBehaviour
{
    public TMP_InputField no1;

    public GameObject welcomePanel;
    public float finalResult;
    
    public void CheckAnswer()
    {
        float val1 = ConvertToFloat(no1.text);
        float a = PlayerPrefs.GetFloat("aVal", 600.0f);
        float b = PlayerPrefs.GetFloat("bVal", -0.11f);
        finalResult = Mathf.Pow((val1 / a), (1.0f / b));
        PlayerPrefs.SetFloat("CurrentResult", finalResult);
        PlayerPrefs.Save();
        if (finalResult >= Mathf.Pow(10,7) && finalResult <= Mathf.Pow(10,8))
        {
            Debug.Log("Correct");
            SceneManager.LoadScene("Level1Success");
            PlayerPrefs.SetInt("ReachedLevel", 2);
        }
        else
        {
            Debug.Log("Incorrect");
            SceneManager.LoadScene("Level1Fail");
        }
    }

    private float ConvertToFloat(string text)
    {
        if (float.TryParse(text, out float result))
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
        if (PlayerPrefs.GetInt("VisitedLevel1", 0) == 1)
        {
            welcomePanel.SetActive(false);
        }
        currentLevel = GetCurrentLevelNumber();
        PlayerPrefs.SetInt("PreviousSceneIndex", currentLevel);
        PlayerPrefs.Save();
    }
}
