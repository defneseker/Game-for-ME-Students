using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedScreen : MonoBehaviour
{
    public void Retry()
    {
        int currentLevel = PlayerPrefs.GetInt("PreviousSceneIndex", 1);
        SceneManager.LoadScene("Level" + (currentLevel));
    }
    public void GoToMap()
    {
        SceneManager.LoadScene("Map");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
