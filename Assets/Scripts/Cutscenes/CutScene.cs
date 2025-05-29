using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour, Trigger
{
    [SerializeReference]
    [SerializeField] List<CutsceneAction> actions;

    public bool TriggerRepeatedly => false;

    public IEnumerator Play()
    {
        GameController.Instance.StartCutsceneState();

        foreach (var action in actions)
        {
            if (action.WaitsForCompletion)
                yield return action.Play();
            else
                StartCoroutine(action.Play());
        }

        GameController.Instance.StartFreemRoamState();
         gameObject.SetActive(false);
    }

    public void addAction(CutsceneAction action)
    {
        actions.Add(action);
    }

    public void onPlayerTrigger(PlayerController player)
    {

        player.Character.Animator.IsCharacterMoving = false;
        StartCoroutine(Play());
    }
}
