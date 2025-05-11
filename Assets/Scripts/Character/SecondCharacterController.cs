using System.Collections;
using UnityEngine;
using System;

public class SecondCharacterController : MonoBehaviour
{
    [SerializeField] Dialog dialogToShow;
    [SerializeField] GameObject view;
    [SerializeField] GameObject alertIcon;

    private Character characterControl;

    private void Awake()
    {
        characterControl = GetComponent<Character>();
    }

   private IEnumerator Start()
{
    yield return null; // attend une frame que tous les Start soient exécutés
    SetViewRotation(characterControl.Animator.ViewDirection);
}

    public IEnumerator LaunchInteractionSequence(PlayerController player)
    {
     
        alertIcon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        alertIcon.SetActive(false);

        Vector3 direction = player.transform.position - transform.position;
        Vector2 movementVector = direction - direction.normalized;
        movementVector = new Vector2(Mathf.Round(movementVector.x), Mathf.Round(movementVector.y));

        yield return characterControl.Move(movementVector);

        StartCoroutine(DialogManager.Instance.Showdialog(dialogToShow, () =>
        {
            Debug.Log("Second character triggered a dialog.");
        }));
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
}