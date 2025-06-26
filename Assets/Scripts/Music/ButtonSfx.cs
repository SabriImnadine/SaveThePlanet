using UnityEngine;
using UnityEngine.UI;

public class ButtonSfx : MonoBehaviour
{
    [SerializeField] private AudioSource sfxPlayer;
    [SerializeField] private AudioClip clickSound;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (sfxPlayer != null && clickSound != null)
                sfxPlayer.PlayOneShot(clickSound);
        });
    }
}
