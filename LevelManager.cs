using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    public Button shopButton;
    void Start()
    {
        int reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > reachedLevel)
            {
                levelButtons[i].interactable = false;
            }
            else 
            {
                levelButtons[i].interactable = true;
            }
        }
    }
    
    public void OpenLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + (levelIndex + 1)); 
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
