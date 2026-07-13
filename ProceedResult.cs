using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedResult : MonoBehaviour
{
    public void LoadFail()
    {
        SceneManager.LoadScene("LevelFail");
    }

    public void LoadSuccess()
    {
        SceneManager.LoadScene("LevelSuccess");
    }
    
}
