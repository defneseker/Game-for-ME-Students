using System;

[System.Serializable]
public struct YesNoQuestion
{
    public string QuestionText;
    public bool answerIsYes;
    public Action<bool> OnSelected;

    public YesNoQuestion(string text, bool isYes, Action<bool> onAnswered) {
        QuestionText = text;
        answerIsYes = isYes;
        OnSelected= onAnswered;
    }
}
