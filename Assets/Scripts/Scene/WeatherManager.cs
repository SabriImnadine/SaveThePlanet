using UnityEngine;
using System.Collections;

public class WeatherManager : MonoBehaviour
{
    public GameObject rainHeavy;
    public GameObject rainLight;

    private ParticleSystem heavySystem;
    private ParticleSystem lightSystem;

    private void Start()
    {
        heavySystem = rainHeavy.GetComponent<ParticleSystem>();
        lightSystem = rainLight.GetComponent<ParticleSystem>();

        UpdateWeatherSmooth();
    }

    public void UpdateWeather()
    {
        UpdateWeatherSmooth(); 
    }

    public void UpdateWeatherSmooth()
    {
        int state = PlayerPrefs.GetInt("ForestQuestState", 0);

        StopAllCoroutines(); 

        if (state == 0)
        {
            StartCoroutine(FadeIn(heavySystem));
            StartCoroutine(FadeOut(lightSystem));
        }
        else if (state == 1)
        {
            StartCoroutine(FadeOut(heavySystem));
            StartCoroutine(FadeIn(lightSystem));
        }
        else if (state == 2)
        {
            StartCoroutine(FadeOut(heavySystem));
            StartCoroutine(FadeOut(lightSystem));
        }
    }

    private IEnumerator FadeIn(ParticleSystem ps)
    {
        var main = ps.main;
        var color = main.startColor.color;
        float duration = 1f;
        float t = 0f;

        ps.gameObject.SetActive(true);
        ps.Play();

        while (t < duration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, t / duration);
            color.a = alpha;
            main.startColor = color;
            yield return null;
        }

        color.a = 1f;
        main.startColor = color;
    }

    private IEnumerator FadeOut(ParticleSystem ps)
    {
        var main = ps.main;
        var color = main.startColor.color;
        float duration = 1f;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / duration);
            color.a = alpha;
            main.startColor = color;
            yield return null;
        }

        ps.Stop();
        ps.gameObject.SetActive(false);
    }
}
