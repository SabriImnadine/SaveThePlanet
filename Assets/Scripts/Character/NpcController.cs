using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController  : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    [SerializeField] float timeBetweenSquence;
    [SerializeField] List<Vector2> pathSequence;



    float waitTimer = 0f;
    NPCState state;
    int currentSequence = 0;

    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }
    public void Interact(Transform initiator)
    {
        if (state == NPCState.Wait)
        {

        state = NPCState.Dialog;
        character.Watching(initiator.position);
        StartCoroutine(DialogManager.Instance.Showdialog(dialog, () => {
          waitTimer = 0f;
          state = NPCState.Wait;  
        }));
        }
    }

    private void Update()
    {
        if (state == NPCState.Wait)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > timeBetweenSquence)
            {
                waitTimer = 0f;
                if (pathSequence.Count > 0)

                StartCoroutine(Movement());
            }
        }
        character.HandleUpdate();
    }
    
    IEnumerator Movement()
    {
        state = NPCState.Walking;

        var oldPosition = transform.position;

       yield return character.Move(pathSequence[currentSequence]);

       if (transform.position != oldPosition)
       currentSequence = (currentSequence + 1) % pathSequence.Count;

        state = NPCState.Wait;
    }
}

public enum NPCState { Wait, Walking, Dialog }
