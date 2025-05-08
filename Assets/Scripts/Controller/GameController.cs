using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog }

public class GameController : MonoBehaviour
{
    [SerializeField] CharacterController playerController;

    GameState state;

    private void Start()
    {
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

    public void StartDialog()
    {
        state = GameState.Dialog;
    }

    public void EndDialog()
    {
        state = GameState.FreeRoam;
    }
}
