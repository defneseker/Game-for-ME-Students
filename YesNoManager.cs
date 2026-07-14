using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using TMPro;

public class YesNoManager : MonoBehaviour
{
    [SerializeField] private YesNoCheck questionUI;
    [SerializeField] private List<YesNoQuestion> questionList;
    public GameObject coinsPanel;
    public TextMeshProUGUI coinsText;

    private int index = 0;
    private LevelTimer levelTimer;
    private bool quizInteractable = true;
    

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

        questionList.Add(new YesNoQuestion("500MPa can be considered a medium-high load and yields about 7.5*10^7 cycles.", true, EvaluateAnswer));
        questionList.Add(new YesNoQuestion("300MPa falls below the endurance limit, so the component will practically never fail under pure fatigue.", true, EvaluateAnswer));
        questionList.Add(new YesNoQuestion("The material will be able to withstand more cycles at pressures closer to its UTS.", false, EvaluateAnswer));
        questionList.Add(new YesNoQuestion("This material can withstand more than 1000MPa pressure with ease.", false, EvaluateAnswer));
        levelTimer = Object.FindFirstObjectByType<LevelTimer>();
        if (levelTimer != null)
        {
            quizInteractable = false;
            SetQuizButtons(false);
        }
        NextQuestion();
    }
    public bool isRunning;
    public void NextQuestion()
    {
        if (index >= questionList.Count) {
            levelTimer.isRunning = false;
            if (PlayerPrefs.GetInt("TookCoinsFrom2", 0) == 0)
            {
                if (levelTimer.timeLeft > 20)
                {
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + 30);
                    coinsText.text = "+ " + "30 Coins!"; 
                }
                else if (levelTimer.timeLeft > 10)
                {
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + 20);
                    coinsText.text = "+ " + "20 Coins!"; 
                }
                else
                {
                    PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + 10);
                    coinsText.text = "+ " + "10 Coins!";
                }
                coinsPanel.SetActive(true);
                PlayerPrefs.SetInt("TookCoinsFrom2", 1);
                PlayerPrefs.Save();
            }
            else{
                SceneManager.LoadScene("LevelSuccess");
            }
            PlayerPrefs.SetInt("ReachedLevel", currentLevel + 1);
            return;
        }
        YesNoQuestion cur = questionList[index];
        cur.OnSelected = EvaluateAnswer;
        questionUI.ShowQuestion(cur);
    }

    private void EvaluateAnswer(bool isCorrect)
    {
        if (!quizInteractable) return;
        if (!isCorrect)
        {
            SceneManager.LoadScene("LevelFail");
            index = 0;
            return;
        }
        index++;
        NextQuestion();
    }

    public void EnableQuizInteraction()
    {
        quizInteractable = true;
        SetQuizButtons(true);
    }

    public void SetQuizButtons(bool state)
    {
        UnityEngine.UI.Button[] buttons = questionUI.GetComponentsInChildren<UnityEngine.UI.Button>();
        foreach (var btn in buttons)
        {
            btn.interactable = state;
        }
    }

    public void GoToSuccess()
    {
        SceneManager.LoadScene("LevelSuccess");
    }
}
