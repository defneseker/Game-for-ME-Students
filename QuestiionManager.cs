using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private QuestionUI questionUI;
    [SerializeField] private List<Question> questionList;
    public int index = 0;

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
        currentLevel = GetCurrentLevelNumber();
        PlayerPrefs.SetInt("PreviousSceneIndex", currentLevel);
        PlayerPrefs.Save();

        questionList.Add(new Question("Alternating stress amplitude = 800 MPa", false, EvaluateAnswer, 800f, 0f, 0f));
        questionList.Add(new Question("Max stress = 400 MPa, Min stress = -400 MPa", true, EvaluateAnswer, 0f, 400f, -400f));
        questionList.Add(new Question("Alternating stress amplitude = 200 MPa", true, EvaluateAnswer, 200f, 0f, 0f));
        questionList.Add(new Question("Max stress = 700 MPa, Min stress = -100 MPa", false, EvaluateAnswer, 0f, 700f, -100f));

        NextQuestion();
    }

    public void NextQuestion()
    {
        if (index >= questionList.Count) {
            SceneManager.LoadScene("LevelSuccess");
            PlayerPrefs.SetInt("ReachedLevel", currentLevel + 1);
            return;
        }
        Question cur = questionList[index];
        cur.OnSelected = EvaluateAnswer;
        questionUI.ShowQuestion(cur);
    }


    public float sum = 0;
    private void EvaluateAnswer(bool wasCorrect, float a)
    {
        if (!wasCorrect)
        {
            SceneManager.LoadScene("LevelFail");
            index = 0;
            return;
        }
        questionUI.aField.text = "";
        if (questionList[index].answerIsInf)
        {
            index++;
            NextQuestion();
            return;
        }
        float N = CalculateN();
        sum += a/N;
        if (sum >= 1 || a == 0)
        {
            SceneManager.LoadScene("LevelFail");
            index = 0;
            return;
        }
        index++;
        NextQuestion();
    }

    public float CalculateN()
    {
        if (index %2 == 0) // Basquin's
        {
            float a = PlayerPrefs.GetFloat("aVal", 600.0f);
            float b = PlayerPrefs.GetFloat("bVal", -0.11f);
            return Mathf.Pow((questionList[index].alt / a), (1.0f / b));
        }
        else // Goodman
        {
            float sigma_m = (questionList[index].max + questionList[index].min) / 2;
            float sigma_a = (questionList[index].max - questionList[index].min) / 2;
            float sigma_ar = sigma_a / (1f - (sigma_m / PlayerPrefs.GetFloat("SutVal", 310f)));
            return Mathf.Pow((sigma_ar / PlayerPrefs.GetFloat("aVal", 600f)), (1.0f / PlayerPrefs.GetFloat("bVal", -0.11f)));
        }
    }
}

