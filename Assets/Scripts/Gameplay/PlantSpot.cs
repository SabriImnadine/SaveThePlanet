using UnityEngine;
using System.Collections;

public class PlantSpot : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog plantDialog;
    [SerializeField] private QuestData quest;
    [SerializeField] private Sprite treeSprite;

    private bool isPlanted = false;

    public void Interact(Transform initiator)
    {
        if (isPlanted || quest == null || !quest.isStarted || quest.isCompleted)
            return;

        StartCoroutine(PlantRoutine());
    }

    private IEnumerator PlantRoutine()
    {
        isPlanted = true;

        if (plantDialog != null)
            yield return DialogManager.Instance.Showdialog(plantDialog);

        GetComponent<SpriteRenderer>().sprite = treeSprite;

        quest.currentAmount++;
        if (quest.currentAmount >= quest.requiredAmount)
        {
            quest.isCompleted = true;
        }
    }
}
