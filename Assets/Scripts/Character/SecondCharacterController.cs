using System.Collections;
using UnityEngine;
using System;

public class SecondCharacterController : MonoBehaviour, Interactable
{
    
    [SerializeField] GameObject view;
    [SerializeField] GameObject alertIcon;
    [SerializeField] private QuestData quest;
    [SerializeField] private GameObject pickupSpawner;
    [SerializeField] private Dialog startDialog;
    [SerializeField] private Dialog inProgressDialog;
    [SerializeField] private Dialog completeDialog;




    private Character characterControl;
    private bool hasAutoInteracted = false;
    private PlayerController playerRef;




    private void Awake()
    {
        characterControl = GetComponent<Character>();
    }

    private IEnumerator Start()
    {
        yield return null;
        quest.ResetProgress();
        SetViewRotation(characterControl.Animator.ViewDirection);
    }

    public IEnumerator LaunchInteractionSequence(PlayerController player)
    {
        if (hasAutoInteracted || quest.isStarted)
        yield break;

        hasAutoInteracted = true;
        playerRef = player;


        alertIcon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        alertIcon.SetActive(false);

        Vector3 direction = player.transform.position - transform.position;
        Vector2 movementVector = direction - direction.normalized;
        movementVector = new Vector2(Mathf.Round(movementVector.x), Mathf.Round(movementVector.y));
        yield return characterControl.Move(movementVector);

        if (!quest.isStarted)
        {
            quest.isStarted = true;
            quest.currentAmount = 0;

            if (pickupSpawner != null)
                pickupSpawner.SetActive(true);

            yield return DialogManager.Instance.Showdialog(startDialog);
            if (view != null)
            view.SetActive(false);

        }
        else if (!quest.isCompleted)
        {
            yield return DialogManager.Instance.Showdialog(inProgressDialog);
            yield break;
        }
        else
        {
            yield return DialogManager.Instance.Showdialog(completeDialog);

        }
    }


    public void SetViewRotation(WatchingDirection dir)
    {
        float rotation = 0f;

        if (dir == WatchingDirection.Right)
            rotation = 90f;
        else if (dir == WatchingDirection.Up)
            rotation = 180f;
        else if (dir == WatchingDirection.Left)
            rotation = 270f;

        view.transform.eulerAngles = new Vector3(0f, 0f, rotation);
    }

    private void Update()
    {
        characterControl.HandleUpdate();
    }

   public void Interact(Transform initiator)
{
    

    playerRef = initiator.GetComponent<PlayerController>();
    if (playerRef != null)
    {
        characterControl.Watching(initiator.position);
        StartCoroutine(ManualInteraction());
    }
    
}


private IEnumerator ManualInteraction()
{
    

    if (!quest.isStarted)
    {
       

        quest.isStarted = true;
        quest.currentAmount = 0;

        if (pickupSpawner != null)
            pickupSpawner.SetActive(true);

        yield return DialogManager.Instance.Showdialog(startDialog);
        yield break;
    }

    if (!quest.isCompleted)
    {
       
        yield return DialogManager.Instance.Showdialog(inProgressDialog);
    }
    else
    {
       
        yield return DialogManager.Instance.Showdialog(completeDialog);
    }
}




}