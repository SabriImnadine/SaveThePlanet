using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    private Image _fadeImage;

    private void Awake()
    {
        _fadeImage = GetComponent<Image>();
    }

    public IEnumerator Show(float duration)
    {
        yield return _fadeImage.DOFade(1f, duration).WaitForCompletion();
    }

    public IEnumerator Hide(float duration)
    {
        yield return _fadeImage.DOFade(0f, duration).WaitForCompletion();
    }
}
