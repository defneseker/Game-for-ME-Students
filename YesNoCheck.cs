using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class YesNoCheck : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    public void ShowQuestion(YesNoQuestion qistin) {
        gameObject.SetActive(true);
        questionText.text = qistin.QuestionText;
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() => {
            bool wasCorrct = (qistin.answerIsYes == true);
            qistin.OnSelected?.Invoke(wasCorrct);
        });

        noButton.onClick.AddListener(() => {
            bool wasCorrct = (qistin.answerIsYes == false);
            qistin.OnSelected?.Invoke(wasCorrct);
        });
    }

    private void Hide() => gameObject.SetActive(false);
}
