using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;



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
    public QuizzBarProgress progressBar;
    public TMP_Text progressLabel;



    [Header("Questions")]
    public List<QuestionData> questions;

    private int currentQuestionIndex = 0;
    private int score = 0;
    private bool answered = false;

    void Start()
    {
        ShowQuestion();
        progressBar.UpdateProgress(currentQuestionIndex + 1);

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
     Debug.Log("Réponse cliquée !");
    answered = true;
    QuestionData q = questions[currentQuestionIndex];

    if (index == q.correctAnswerIndex)
    {
        score++;
    }

    for (int i = 0; i < answerButtons.Count; i++)
    {
        Image btnImage = answerButtons[i].GetComponent<Image>();
        TMP_Text btnText = answerButtons[i].GetComponentInChildren<TMP_Text>();

            if (i == q.correctAnswerIndex)
            {
                btnImage.color = Color.green;
              btnText.color = new Color(0.2f, 0.9f, 0.6f); 

            }
            else if (i == index)
            {
                btnImage.color = Color.red;
                 btnText.color = new Color(1f, 0.4f, 0.4f);
            }
            else
            {
                btnImage.color = Color.white;
            }

        answerButtons[i].interactable = false;
    }

    nextButton.interactable = true;
}


    void NextQuestion()
    {
         Debug.Log("Next cliqué !");
        currentQuestionIndex++;


        if (currentQuestionIndex < questions.Count)
        {
            ResetButtonColors();
            ShowQuestion();
            progressBar.UpdateProgress(currentQuestionIndex + 1);
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
            btn.GetComponent<Image>().color = Color.white;
         btn.GetComponentInChildren<TMP_Text>().color = Color.white;
    }
}

void EndQuiz()
{
    foreach (var btn in answerButtons)
    btn.gameObject.SetActive(false);
    progressBar.Hide();
    nextButton.gameObject.SetActive(false);

    RectTransform rt = questionText.GetComponent<RectTransform>();
    rt.anchorMin = new Vector2(0.5f, 0.5f);
    rt.anchorMax = new Vector2(0.5f, 0.5f);
    rt.pivot = new Vector2(0.5f, 0.5f);
    rt.anchoredPosition = Vector2.zero;


    questionText.alignment = TextAlignmentOptions.Center;
    questionText.fontSize = 28; 

    questionText.text =
    "<size=36>Je hebt de quiz voltooid!</size>\n" +
    $"<size=30>Je score: {score}/{questions.Count}</size>\n\n" +
    $"<i>{GetEcoMessage(score)}</i>\n\n" +
    "<size=26><color=#A0FFD0>Bedankt om deel te nemen aan dit avontuur.</color>\n" +
    "Elke stap die je zet helpt onze planeet.\n" +
    "Samen kunnen we een verschil maken.</size>\n\n" +
    $"<size=20><color=#CCCCCC>Terug naar het menu in 15 seconden...</color></size>";



    
   StartCoroutine(CountdownToMenu());

}

string GetEcoMessage(int score)
{
    if (score >= 8) return "Fantastisch! Je bent een echte klimaatexpert";
    if (score >= 5) return "Goed gedaan! Je weet al best veel, blijf leren!";
    return "Er is nog werk aan de winkel, maar elke stap telt.";
}

IEnumerator CountdownToMenu()
{
    int seconds = 15;

    string baseMessage =
        $"Je hebt de quiz voltooid!\n" +
        $"Je score: {score}/{questions.Count}\n\n" +
        $"{GetEcoMessage(score)}\n\n" +
        "Bedankt om deel te nemen aan dit avontuur.\n" +
        "Elke stap die je zet helpt onze planeet.\n" +
        "Samen kunnen we een verschil maken.";

    for (int i = seconds; i > 0; i--)
    {
        questionText.text = baseMessage + $"\n\nTerug naar het menu in {i} seconden...";
        yield return new WaitForSeconds(1);
    }

    questionText.text = baseMessage + "\n\nLaden van het hoofdmenu...";
    yield return new WaitForSeconds(5);

    ReturnToMainMenu();
}


    void ReturnToMainMenu()
{
    UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
}
}
