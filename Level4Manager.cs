using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Level4Manager : MonoBehaviour
{
    public GameObject instructionsPanel;
    private QuestionManager questionManager;

    public int GetCurrentLevelNumber()
    {
       string sceneName = SceneManager.GetActiveScene().name;
        Match match = Regex.Match(sceneName, @"\d+");
        if (match.Success)
        {
            return int.Parse(match.Value);
        }
        return 0;
    }

    int currentLevel;
    void Start()
    {
        if (PlayerPrefs.GetInt("VisitedLevel4", 0) == 1)
        {
            instructionsPanel.SetActive(false);
        }
        currentLevel = GetCurrentLevelNumber();
        PlayerPrefs.SetInt("PreviousSceneIndex", currentLevel);
        PlayerPrefs.Save();
        questionManager = Object.FindFirstObjectByType<QuestionManager>();
    }

    public void GoToLevel()
    {
        instructionsPanel.SetActive(false);
        PlayerPrefs.SetInt("VisitedLevel4", 1);
        PlayerPrefs.Save();
    }

    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }
}
