using UnityEngine;

public class SeedPickup : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog pickupDialog;

    public void Interact(Transform initiator)
    {
        PlayerInventory inventory = initiator.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.hasSeeds = true;

            if (pickupDialog != null)
                StartCoroutine(DialogManager.Instance.Showdialog(pickupDialog));

            Destroy(gameObject);
        }
    }
}
