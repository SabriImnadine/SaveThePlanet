using System.Collections;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public event Action<Collider2D> OnEnterSecondCharacterView;
    private Vector2 input;
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void HandleUpdate()
    {
        if (!character.IsCharacterMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                StartCoroutine(character.Move(input, OnOver));
            }
        }

        character.HandleUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
            Interact();
    }

    void Interact()
    {
        var facingDir = new Vector3(character.Animator.HorizontalInput, character.Animator.VerticalInput);
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, Layers.i.InteractableLayer);
        if (collider != null)
        {
            character.ResetAnimationState();
            collider.GetComponent<Interactable>()?.Interact(transform);
        }
    }

    private void OnOver()
    {
    var colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f, Layers.i.TriggerLayer);

    foreach (var collider in colliders)
    {
        var triggerable = collider.GetComponent<Trigger>();
        if (triggerable != null)
        {
            triggerable.onPlayerTrigger(this);
            break;
        }
    }

     CheckIfInSecondCharacterView();
    }


    private void CheckIfInSecondCharacterView()
    {
        
    Collider2D detectedField = Physics2D.OverlapCircle(transform.position, 0.2f, Layers.i.ViewLayer);
    
    if (detectedField != null)
    {
        character.Animator.IsCharacterMoving = false;
        OnEnterSecondCharacterView?.Invoke(detectedField);
    }
    }

    public Character Character => character;

}

