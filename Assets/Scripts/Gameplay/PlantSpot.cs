using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlantSpot : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog digDialog;
    [SerializeField] private Dialog plantDialog;
    [SerializeField] private QuestData quest;
    [SerializeField] private Sprite treeSprite;
    [SerializeField] private List<Dialog> digProgressDialogs;


    private bool isDug = false;
    private bool isPlanted = false;
    private int digProgress = 0;
    private int digRequired = 8;
     private SpriteRenderer spriteRenderer;

    private void Awake()
    {
    spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Interact(Transform initiator)
    {
            StartCoroutine(HandleInteraction(initiator));
    }

    private IEnumerator HandleInteraction(Transform initiator)
    {
        PlayerInventory inventory = initiator.GetComponent<PlayerInventory>();
        if (inventory == null || isPlanted || quest == null || !quest.isStarted || quest.isCompleted)
            yield break;

        if (!isDug)
        {
            if (!inventory.hasShovel)
            {
                yield break;
            }
            digProgress++;
            float progressRatio = (float)digProgress / digRequired;
            spriteRenderer.color = Color.Lerp(Color.white, Color.black, progressRatio * 0.6f);

            if (digProgress - 1 < digProgressDialogs.Count)
            {
                yield return DialogManager.Instance.Showdialog(digProgressDialogs[digProgress - 1]);
            }


            if (digProgress >= digRequired)
            {
                isDug = true;

                if (digDialog != null)
                    yield return DialogManager.Instance.Showdialog(digDialog);
            }
        }
        else
        {
            if (!inventory.hasSeeds)
            {
                yield break;
            }
            yield return PlantRoutine(inventory);
        }
    }

    private IEnumerator PlantRoutine(PlayerInventory inventory)
    {
        isPlanted = true;
       // inventory.hasSeeds = false;

        if (plantDialog != null)
            yield return DialogManager.Instance.Showdialog(plantDialog);

        GetComponent<SpriteRenderer>().sprite = treeSprite;
         spriteRenderer.color = Color.white;

        quest.currentAmount++;
        if (quest.currentAmount >= quest.requiredAmount)
        {
            quest.isCompleted = true;
        }
    }

   
}
