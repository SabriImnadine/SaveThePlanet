using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public List<string> answers;
        public int correctAnswerIndex;
    }

    [Header("UI References")]
    public TMP_Text questionText;
    public List<Button> answerButtons;
    public Button nextButton;

    [Header("Questions")]
    public List<QuestionData> questions;

    private int currentQuestionIndex = 0;
    private int score = 0;
    private bool answered = false;

    void Start()
    {
        ShowQuestion();
        nextButton.onClick.AddListener(NextQuestion);
    }

    void ShowQuestion()
    {
        answered = false;
        QuestionData q = questions[currentQuestionIndex];
        questionText.text = q.question;

        for (int i = 0; i < answerButtons.Count; i++)
        {
            TMP_Text btnText = answerButtons[i].GetComponentInChildren<TMP_Text>();
            btnText.text = q.answers[i];
            int index = i;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
            answerButtons[i].interactable = true;
        }

        nextButton.interactable = false;
    }

    void OnAnswerSelected(int index)
    {
        answered = true;
        QuestionData q = questions[currentQuestionIndex];

        if (index == q.correctAnswerIndex)
        {
            score++;
        }

        // Indicate correct/wrong visually
        for (int i = 0; i < answerButtons.Count; i++)
        {
            ColorBlock cb = answerButtons[i].colors;
            cb.normalColor = (i == q.correctAnswerIndex) ? Color.green : Color.red;
            answerButtons[i].colors = cb;
            answerButtons[i].interactable = false;
        }

        nextButton.interactable = true;
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            ResetButtonColors();
            ShowQuestion();
        }
        else
        {
            EndQuiz();
        }
    }

    void ResetButtonColors()
    {
        foreach (var btn in answerButtons)
        {
            ColorBlock cb = btn.colors;
            cb.normalColor = Color.white;
            btn.colors = cb;
        }
    }

    void EndQuiz()
    {
        questionText.text = $"Je hebt de quiz voltooid!\nJe score: {score}/{questions.Count}";

        foreach (var btn in answerButtons)
            btn.gameObject.SetActive(false);

        nextButton.gameObject.SetActive(false);
    }
}
