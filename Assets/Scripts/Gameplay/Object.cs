using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog pickupDialog;
    [SerializeField] private QuestData quest; // ← AJOUT ICI

    public void Interact(Transform initiator)
    {
        StartCoroutine(PickupRoutine());
    }

    private IEnumerator PickupRoutine()
    {
        if (quest == null || !quest.isStarted || quest.isCompleted)
            yield break;

        if (pickupDialog != null)
            yield return DialogManager.Instance.Showdialog(pickupDialog);

        quest.currentAmount++;

        if (quest.currentAmount >= quest.requiredAmount)
            quest.isCompleted = true;

        Destroy(gameObject);
    }
}

