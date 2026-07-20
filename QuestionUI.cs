using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private Button infButton;
    [SerializeField] private Button okButton;
    [SerializeField] public TMP_InputField aField;

    public void ShowQuestion(Question qistin) {
        gameObject.SetActive(true);
        questionText.text = qistin.QuestionText;
        infButton.onClick.RemoveAllListeners();
        okButton.onClick.RemoveAllListeners();

        infButton.onClick.AddListener(() => {
            bool wasCorrct = (qistin.answerIsInf == true);
            qistin.OnSelected?.Invoke(wasCorrct, 0f);
        });

        okButton.onClick.AddListener(() => {
            bool wasCorrct = (qistin.answerIsInf == false);
            qistin.OnSelected?.Invoke(wasCorrct, float.Parse(aField.text));
        });
    }

    private void Hide() => gameObject.SetActive(false);
}
