using UnityEngine;

public class ShovelPickup : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog pickupDialog;

    public void Interact(Transform initiator)
    {
        PlayerInventory inventory = initiator.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.hasShovel = true;

            if (pickupDialog != null)
                StartCoroutine(DialogManager.Instance.Showdialog(pickupDialog));
            Destroy(gameObject);
        }
    }
}
