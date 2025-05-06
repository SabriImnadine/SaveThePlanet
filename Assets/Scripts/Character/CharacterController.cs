using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask solidObjectsLayer;

    private bool isMoving = false;
    private Vector2 input;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                Vector3 targetPos = transform.position + new Vector3(input.x, input.y, 0f);
                
                if(IsWalkable(targetPos))
                StartCoroutine(Move(targetPos));
            }
        }
        
        animator.SetBool("isMoving", isMoving);
    }

    private IEnumerator Move(Vector3 destination)
    {
        isMoving = true;

        while ((destination - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
      if  (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer ) !=  null)
      {
        return false;
      }
      return true;
    }
}
