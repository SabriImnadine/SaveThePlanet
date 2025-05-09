using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
                StartCoroutine(character.Move(input));
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
            collider.GetComponent<Interactable>()?.Interact();
        }
    }
}

