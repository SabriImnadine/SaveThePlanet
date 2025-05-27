using UnityEngine;

public class LightSwitch : MonoBehaviour, Interactable
{
    [SerializeField] private Sprite lightOffSprite;
    [SerializeField] private Sprite lightOnSprite;
    [SerializeField] private GameObject roomDarkness;
    [SerializeField] private string lampID;
    [SerializeField] private SpriteRenderer lampRenderer;
    [SerializeField] private AudioClip switchSfx;
    [SerializeField] private AudioSource sfxPlayer;


    private bool isOff;

    private void Start()
    {
        isOff = PlayerPrefs.GetInt(lampID, 0) == 1;
        UpdateVisual();

        if (isOff && !WasLampCounted())
        {
            MarkLampAsCounted();
        }
        
    }

    public void Interact(Transform initiator)
    {
        isOff = !isOff;
        PlayerPrefs.SetInt(lampID, isOff ? 1 : 0);
        UpdateVisual();

        if (isOff && !WasLampCounted())
        {
            MarkLampAsCounted();
        }

          if (switchSfx != null && sfxPlayer != null)
            sfxPlayer.PlayOneShot(switchSfx);
    }

    private void UpdateVisual()
    {
        if (lampRenderer != null)
            lampRenderer.sprite = isOff ? lightOffSprite : lightOnSprite;

        if (roomDarkness != null)
            roomDarkness.SetActive(isOff);
    }

    private bool WasLampCounted()
    {
        return PlayerPrefs.GetInt(lampID + "_done", 0) == 1;
    }

    private void MarkLampAsCounted()
    {
        PlayerPrefs.SetInt(lampID + "_done", 1);
    }
}
