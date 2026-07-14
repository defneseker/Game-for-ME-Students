using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class Level3Manager : MonoBehaviour
{
    public TMP_InputField no1;
    public TMP_InputField no2;
    public TMP_InputField no3;
    
    
    public void CheckStep1()
    {
        float val1 = ConvertToFloat(no1.text);
        float val2 = ConvertToFloat(no2.text);
        if (val1 == 10 && val2 == 6)
        {
            Debug.Log("Correct");
            SceneManager.LoadScene("Level3Step1Done");
        }
        else 
        {
            Debug.Log("Incorrect");
            SceneManager.LoadScene("Level3Fail");
        }
    }

    public void CheckStep2()
    {
        float val3 = ConvertToFloat(no3.text);
        float expectedResult = (6 / PlayerPrefs.GetInt("SeVal", 100)) + (10 / PlayerPrefs.GetInt("SutVal", 310));
        if (val3 == expectedResult)
        {
            Debug.Log("Correct");
            SceneManager.LoadScene("Level3Success");
        }
        else 
        {
            Debug.Log("Incorrect");
            SceneManager.LoadScene("Level3Fail");
        }
    }

    private float ConvertToFloat(string text)
    {
        if (float.TryParse(text, out float result))
        {
            return result;
        }
        return 0f; 
    }
}
