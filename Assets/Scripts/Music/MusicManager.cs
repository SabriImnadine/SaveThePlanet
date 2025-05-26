using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioSource sfxPlayer;
    [SerializeField] float fadeDuration = 0.6f;

    float OriginalAudioVol;

    public static MusicManager i { get; private set; }

    private void Awake()
    {
        if (i == null)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        OriginalAudioVol = audioPlayer.volume;
    }
    public void PlayAudio(AudioClip clip, bool loop = true, bool fade = false)
    {
        if (clip == null) return;

        StartCoroutine(PlayAudioAsync(clip, loop, fade));


    }

    IEnumerator PlayAudioAsync(AudioClip clip, bool loop, bool fade)
    {
        if (fade)
            yield return audioPlayer.DOFade(0, fadeDuration).WaitForCompletion();

        audioPlayer.clip = clip;
        audioPlayer.loop = loop;
        audioPlayer.Play();
        
         if (fade)
            yield return audioPlayer.DOFade(OriginalAudioVol, fadeDuration).WaitForCompletion();

    }
}
