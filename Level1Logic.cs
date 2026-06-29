using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Level1Finish : MonoBehaviour
{
    public TMP_InputField no1;
    public TMP_InputField no2;
    
    public void CheckAnswer()
    {
        float val1 = ConvertToFloat(no1.text);
        float val2 = ConvertToFloat(no2.text);
        float finalResult = val1 + val2;
        if (finalResult == 5)
        {
            Debug.Log("Correct");
            SceneManager.LoadScene("LevelSuccess");
            PlayerPrefs.SetInt("ReachedLevel", 2);
        }
        else
        {
            Debug.Log("Incorrect");
            SceneManager.LoadScene("LevelFail");
        }
    }

    private float ConvertToFloat(string text)
    {
        if (float.TryParse(text, out float result))
        {
            return result;
        }
        return 0f; // Returns 0 if the field was left empty
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
    }
}
