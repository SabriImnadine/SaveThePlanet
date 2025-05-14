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

    PlayerController player;
 
    
    public void onPlayerTrigger(PlayerController player)
    {
        this.player = player;
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        DontDestroyOnLoad(gameObject);
        GameController.Instance.PauseTheGame(true);

        yield return SceneManager.LoadSceneAsync(sceneToCharge);

        var destinationTP = Object.FindObjectsByType<TP>(FindObjectsSortMode.None).FirstOrDefault(x => x != this && x.tpdefiner == this.tpdefiner);

        player.Character.SnapToTile(destinationTP.Spawn.position);

        GameController.Instance.PauseTheGame(false);

        yield break;
    }


    public Transform Spawn => spawn;
}

public enum TPDefiner { TP1, TP2, TP3, TP4 }


