using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
            return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(moveX, moveY);

        if (moveInput != Vector2.zero)
        {
            Vector3 destination = transform.position + new Vector3(moveInput.x, moveInput.y, 0f);
            StartCoroutine(MoveTo(destination));
        }
    }

    private IEnumerator MoveTo(Vector3 destination)
    {
        isMoving = true;

        while ((destination - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }
}


