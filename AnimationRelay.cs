using UnityEngine;

public class AnimEventRelay : MonoBehaviour
{
    [SerializeField] private QuestionUI questionUI;
    public void OnFeedbackAnimationFinished() => questionUI.OnFeedbackAnimationFinished();
}
