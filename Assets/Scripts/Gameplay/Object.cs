using UnityEngine;
using System.Collections;

public class Object : MonoBehaviour, Interactable
{
    [SerializeField] private Dialog pickupDialog;

    public void Interact(Transform initiator)
    {
        StartCoroutine(PickupRoutine());
    }

    private IEnumerator PickupRoutine()
    {
        Debug.Log("Pickup is working");

        if (pickupDialog != null)
        {
            yield return DialogManager.Instance.Showdialog(pickupDialog);
        }

        Destroy(gameObject); 
    }
}
