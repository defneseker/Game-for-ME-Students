using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject welcomePanel;
    [SerializeField] private Button goButton;
    [SerializeField] private GameObject instructionsPanel;

    public void AdvanceDialogue()
    {
        welcomePanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void GoToLevel()
    {
        instructionsPanel.SetActive(false);
    }
    
}
