using UnityEngine;
using System.Collections;

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
            {
                StartCoroutine(PickupRoutine(inventory));
            }
            else
            {
                inventory.hasSeeds = true;
                Destroy(gameObject);
            }
        }
    }
  private IEnumerator PickupRoutine(PlayerInventory inventory)
{
    yield return DialogManager.Instance.Showdialog(pickupDialog);
    inventory.hasSeeds = true;
    Destroy(gameObject);
}

}
