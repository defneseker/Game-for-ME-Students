using UnityEngine;
using UnityEngine.SceneManagement;

public class PassedScreen : MonoBehaviour
{
    int reachedLevel;
    void Start()
    {
        reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene("Level" + (reachedLevel));
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
