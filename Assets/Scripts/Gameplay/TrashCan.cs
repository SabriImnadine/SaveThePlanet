using UnityEngine;

public class TrashCan : MonoBehaviour, Interactable
{
    [SerializeField] private QuestData quest; 
    [SerializeField] private Dialog trashDialog; 

    public void Interact(Transform initiator)
    {
        PlayerInventory inventory = initiator.GetComponent<PlayerInventory>();

        if (inventory != null && quest.isStarted && !quest.isCompleted && inventory.trashCount > 0)
        {
            quest.currentAmount += inventory.trashCount;
            inventory.trashCount = 0;

            if (quest.currentAmount >= quest.requiredAmount)
                quest.isCompleted = true;

            if (trashDialog != null)
            {
                StartCoroutine(DialogManager.Instance.Showdialog(trashDialog));
            }
        }
    }
}
