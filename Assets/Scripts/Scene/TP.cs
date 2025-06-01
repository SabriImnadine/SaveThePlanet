using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour, Trigger


{


    [SerializeField] int sceneToCharge = -1;
    [SerializeField] TPDefiner tpdefiner;
    [SerializeField] Transform spawn;
    [SerializeField] private AudioClip tpSound;


    PlayerController player;
     private Fade fade;
 
    
    public void onPlayerTrigger(PlayerController player)
    {
        this.player = player;
        StartCoroutine(NextScene());
    }

    private void Start()
    {
        fade = FindFirstObjectByType<Fade>();
    }
    
    IEnumerator NextScene()
    {
        DontDestroyOnLoad(gameObject);
        GameController.Instance.PauseTheGame(true);

        player.Character.ResetAnimationState();

        if (tpSound != null)
        MusicManager.i.PlaySFX(tpSound);


        yield return fade.Show(0.6f);

        yield return SceneManager.LoadSceneAsync(sceneToCharge);

        var destinationTP = Object.FindObjectsByType<TP>(FindObjectsSortMode.None).FirstOrDefault(x => x != this && x.tpdefiner == this.tpdefiner);

        player.Character.SnapToTile(destinationTP.Spawn.position);

        yield return fade.Hide(0.6f);
        GameController.Instance.PauseTheGame(false);
        Destroy(gameObject);

        yield break;
    }


    public Transform Spawn => spawn;
}


public enum TPDefiner { TP1, TP2, TP3, TP4, TP5, TP6, TP7, TP8 }


