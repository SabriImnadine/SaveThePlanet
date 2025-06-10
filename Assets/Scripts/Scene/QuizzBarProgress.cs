using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class QuizzBarProgress : MonoBehaviour
{
    public Slider progressSlider;
    public TextMeshProUGUI progressText;
    public int totalQuestions = 10;

    public void UpdateProgress(int currentQuestion)
    {
        float progress = (float)(currentQuestion - 1) / (totalQuestions - 1);
        progressSlider.DOValue(progress, 0.5f).SetEase(Ease.OutQuad);
        progressText.text = $"Vraag {currentQuestion}/{totalQuestions}";
    }

    public void Hide()
{
    progressSlider.gameObject.SetActive(false);
    progressText.gameObject.SetActive(false);
}

}
