using UnityEngine;
using TMPro;

public class AnimationOverlayController : MonoBehaviour
{
    public GameObject panelToOpen;
    public TextMeshProUGUI resultText;

    public void OnAnimationComplete()
    {
        if (panelToOpen != null)
        {
            resultText.text = PlayerPrefs.GetFloat("CurrentResult").ToString();
            panelToOpen.SetActive(true);
        }
    }
}
