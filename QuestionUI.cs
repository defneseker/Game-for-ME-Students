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

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private string animationName = "level4_correct";
    [SerializeField] private GameObject animationObject;
    [SerializeField] private GameObject idleObject;
    [SerializeField] private GameObject questionPanel;

    private System.Action onAnimationEnd;
    

    public void ShowQuestion(Question qistin) {
        gameObject.SetActive(true);
        questionPanel.SetActive(true);
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

    public void PlayCorrectAnimation(System.Action onComplete) {
        onAnimationEnd = onComplete;
        questionPanel.SetActive(false);
        idleObject.SetActive(false);
        animationObject.SetActive(true);
        animator.Play(animationName, 0, 0f);
        animator.Update(0f);
    }

    public void OnFeedbackAnimationFinished()
    {
        animationObject.SetActive(false);
        idleObject.SetActive(true);
        questionPanel.SetActive(true);
        onAnimationEnd?.Invoke();
        onAnimationEnd = null;
    }

    private void Hide() => gameObject.SetActive(false);
}
