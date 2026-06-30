using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class LevelTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float timeLeft = 30f;
    private bool isRunning = false;
    [SerializeField] private TextMeshProUGUI timeDisplay;
    [SerializeField] private Button startTimerButton;

    private YesNoManager yesNoManager;

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
        yesNoManager = Object.FindFirstObjectByType<YesNoManager>();
    }

    public void StartTimer()
    {
        isRunning = true;
        if (yesNoManager != null)
        {
            yesNoManager.EnableQuizInteraction();
        }
        if (startTimerButton != null)
        {
            startTimerButton.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isRunning) {
            if (timeLeft > 0) {
            timeLeft -=Time.deltaTime;
            DisplayTime(timeLeft);
            }
            else {
                timeLeft = 0;
                isRunning = false;
                DisplayTime(timeLeft);
                SceneManager.LoadScene("LevelFail");
                return;
            }
        }
    }

    private void DisplayTime(float time)
    {
        int mins = Mathf.FloorToInt(time / 60);
        int secs = Mathf.FloorToInt(time % 60);
        timeDisplay.text = string.Format ("{0:00}:{1:00}", mins, secs);
    }
}
