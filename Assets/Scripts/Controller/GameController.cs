using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Stopscene, Paused }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    GameState state;
    GameState StateBeforePause;

    public static GameController Instance { get; private set; }

    private void Awake()
    {
    if (Instance == null)
        Instance = this;
    else
        Destroy(gameObject);
    }


    private void Start()
    {
        playerController.OnEnterSecondCharacterView += (Collider2D secondcharacterCollider ) =>
        {
            var secondcharacter = secondcharacterCollider.GetComponentInParent<SecondCharacterController>();

            if (secondcharacter !=null )
            {
                state = GameState.Stopscene;
                StartCoroutine(secondcharacter.LaunchInteractionSequence(playerController));

            }
        };  

        DialogManager.Instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };

        DialogManager.Instance.OnCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
        };
    }

    private void Update()
    {
        if (state == GameState.Dialog)
        {
           DialogManager.Instance.HandleUpdate();
        }
        else if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
    }

    public void PauseTheGame(bool  pause)
    {
        if (pause)
        {
            StateBeforePause = state;
            state = GameState.Paused;
        }
        else
        {
            state = StateBeforePause;
        }
    }

    public void StartDialog()
    {
        state = GameState.Dialog;
    }

    public void EndDialog()
    {
        state = GameState.FreeRoam;
    }
}
