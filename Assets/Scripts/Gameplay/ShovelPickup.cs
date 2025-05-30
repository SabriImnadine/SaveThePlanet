using UnityEngine;
using System.Collections;

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
            {
                StartCoroutine(PickupRoutine(inventory));
            }
            else
            {
                inventory.hasShovel = true; 
                Destroy(gameObject);
            }

        }
    }
    
    private IEnumerator PickupRoutine(PlayerInventory inventory)
{
    yield return DialogManager.Instance.Showdialog(pickupDialog);
    inventory.hasShovel = true;
    Destroy(gameObject);
}

}
