using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class YesNoManager : MonoBehaviour
{
    [SerializeField] private YesNoCheck questionUI;
    [SerializeField] private List<YesNoQuestion> questionList;

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

        questionList.Add(new YesNoQuestion("ex question1, a: yes", true, EvaluateAnswer));
        questionList.Add(new YesNoQuestion("ex question2, a:no", false, EvaluateAnswer));
        levelTimer = Object.FindFirstObjectByType<LevelTimer>();
        if (levelTimer != null)
        {
            quizInteractable = false;
            SetQuizButtons(false);
        }
        NextQuestion();
    }

    public void NextQuestion()
    {
        if (index >= questionList.Count) {
            SceneManager.LoadScene("LevelSuccess");
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
}
