using System;

[System.Serializable]
public struct Question
{
    public string QuestionText;
    public bool answerIsInf;
    public Action<bool, float> OnSelected;
    public float alt;
    public float max;
    public float min;

    public Question(string text, bool isInf, Action<bool, float> onAnswered, float alt, float max, float min) {
        QuestionText = text;
        answerIsInf = isInf;
        OnSelected= onAnswered;
        this.alt = alt;
        this.max = max;
        this.min = min;
    }
}