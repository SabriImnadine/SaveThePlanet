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
    [SerializeField] private bool isLightQuest = false;
    [SerializeField] private AudioClip alertSound;

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
        Debug.Log($"[LOAD] {quest.questName} | started={PlayerPrefs.GetInt(quest.questName + "_started", 0)} | completed={PlayerPrefs.GetInt(quest.questName + "_completed", 0)} | current={PlayerPrefs.GetInt(quest.questName + "_current", 0)}");

        quest.isStarted = PlayerPrefs.GetInt(quest.questName + "_started", 0) == 1;
        quest.isCompleted = PlayerPrefs.GetInt(quest.questName + "_completed", 0) == 1;
        quest.currentAmount = PlayerPrefs.GetInt(quest.questName + "_current", 0);
        quest.hasBeenAcknowledged = PlayerPrefs.GetInt(quest.questName + "_acknowledged", 0) == 1;

        SetViewRotation(characterControl.Animator.ViewDirection);
        if (quest.isStarted) view.SetActive(false);
    }

    public IEnumerator LaunchInteractionSequence(PlayerController player)
    {
        if (hasAutoInteracted || quest.isStarted)
            yield break;

        hasAutoInteracted = true;
        playerRef = player;

        if (alertSound != null)
        MusicManager.i.PlaySFX(alertSound);

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
            SaveQuestState();


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
            SaveQuestState();


            if (pickupSpawner != null)
                pickupSpawner.SetActive(true);

            yield return DialogManager.Instance.Showdialog(startDialog);
            yield break;
        }

        if (!quest.isCompleted)
        {
            if (isLightQuest)
            {
                bool lamp1 = PlayerPrefs.GetInt("Room1_done", 0) == 1;
                bool lamp2 = PlayerPrefs.GetInt("Room2_done", 0) == 1;
                bool lamp3 = PlayerPrefs.GetInt("Room3_done", 0) == 1;

                if (lamp1 && lamp2 && lamp3)
                {
                    quest.isCompleted = true;
                    quest.hasBeenAcknowledged = true; 
                    SaveQuestState();
                    yield return DialogManager.Instance.Showdialog(completeDialog);
                }
                else
                {
                    yield return DialogManager.Instance.Showdialog(inProgressDialog);
                }

                yield break;
            }

        
            if (quest.currentAmount >= quest.requiredAmount)
            {
                quest.isCompleted = true;
                SaveQuestState();
                yield return DialogManager.Instance.Showdialog(completeDialog);
            }
            else
            {
                yield return DialogManager.Instance.Showdialog(inProgressDialog);
            }

            yield break;
        }
yield return DialogManager.Instance.Showdialog(completeDialog);

if (!quest.hasBeenAcknowledged)
{
    quest.hasBeenAcknowledged = true;
    SaveQuestState();
}

}
    private void SaveQuestState()
    {
        PlayerPrefs.SetInt(quest.questName + "_started", quest.isStarted ? 1 : 0);
        PlayerPrefs.SetInt(quest.questName + "_completed", quest.isCompleted ? 1 : 0);
        PlayerPrefs.SetInt(quest.questName + "_current", quest.currentAmount);
    PlayerPrefs.SetInt(quest.questName + "_acknowledged", quest.hasBeenAcknowledged ? 1 : 0);

}
}