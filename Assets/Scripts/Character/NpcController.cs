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
    public void Interact()
    {
        if (state == NPCState.Wait)
       StartCoroutine(DialogManager.Instance.Showdialog(dialog));
    }

    private void Update()
    {
        if (DialogManager.Instance.IsReading) return;

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

       yield return character.Move(pathSequence[currentSequence]);
       currentSequence = (currentSequence + 1) % pathSequence.Count;

        state = NPCState.Wait;
    }
}

public enum NPCState { Wait, Walking }
