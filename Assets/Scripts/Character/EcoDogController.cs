using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoDogController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float followSpeed = 3f;
    [SerializeField] private float followDistance = 1.5f;
    [SerializeField] private float idleTimeBeforeSit = 15f;
   
    [Header("Animations")]
    [SerializeField] private AnimatorCharacter animator;

    [SerializeField] private List<Sprite> walkDownSprites;
    [SerializeField] private List<Sprite> walkUpSprites;
    [SerializeField] private List<Sprite> walkLeftSprites;
    [SerializeField] private List<Sprite> walkRightSprites;

    [SerializeField] private List<Sprite> sitDownSprites;
    [SerializeField] private List<Sprite> sitUpSprites;
    [SerializeField] private List<Sprite> sitLeftSprites;
    [SerializeField] private List<Sprite> sitRightSprites;

    private Vector3 lastPlayerPosition;
    private float idleTimer = 0f;
    private bool isSitting = false;
    private bool isAnimating = false;
    

    private WatchingDirection currentDirection;
    private Coroutine currentWalkCoroutine;
    private WatchingDirection lastAnimatedDirection;




    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            player = playerObject.transform;
        else
            Debug.LogError("EcoDogController: Aucun objet avec le tag 'Player' trouvé.");

        lastPlayerPosition = player.position;
    }
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > followDistance)
        {
            Vector3 rawDirection = player.position - transform.position;
            Vector3 moveDirection = Vector3.zero;

            // ❌ PAS de déplacement diagonal — priorité à l'axe le plus éloigné
            if (Mathf.Abs(rawDirection.x) > Mathf.Abs(rawDirection.y))
                moveDirection = new Vector3(Mathf.Sign(rawDirection.x), 0f, 0f);
            else
                moveDirection = new Vector3(0f, Mathf.Sign(rawDirection.y), 0f);

            // Déplacement
           if (IsWalkable(moveDirection))
{
    transform.position += moveDirection * followSpeed * Time.deltaTime;
}

            // Animation (input simulé pour AnimatorCharacter si tu l'utilises)
            if (animator != null)
            {
                animator.HorizontalInput = moveDirection.x > 0.1f ? 1 : moveDirection.x < -0.1f ? -1 : 0;
                animator.VerticalInput = moveDirection.y > 0.1f ? 1 : moveDirection.y < -0.1f ? -1 : 0;
                animator.IsCharacterMoving = true;
            }

            UpdateDirection(moveDirection);
            isSitting = false;
            idleTimer = 0f;

            if (currentDirection != lastAnimatedDirection || !isAnimating)
            {
                lastAnimatedDirection = currentDirection;

                if (currentWalkCoroutine != null)
                    StopCoroutine(currentWalkCoroutine);

                currentWalkCoroutine = StartCoroutine(PlayWalkAnimation());
            }
        }
        else
        {
            if (Vector2.Distance(player.position, lastPlayerPosition) < 0.01f)
            {
                idleTimer += Time.deltaTime;
                if (idleTimer >= idleTimeBeforeSit && !isSitting)
                {
                    SitDown();
                }
            }
            else
            {
                idleTimer = 0f;
                isSitting = false;
                lastPlayerPosition = player.position;
            }


            if (animator != null)
            {
                animator.IsCharacterMoving = false;
            }

            if (currentWalkCoroutine != null)
            {
                StopCoroutine(currentWalkCoroutine);
                currentWalkCoroutine = null;
            }
            if (!isSitting)
            {

                // Reste immobile sur la bonne frame de direction
                List<Sprite> idleSprites = currentDirection switch
                {
                    WatchingDirection.Up => walkUpSprites,
                    WatchingDirection.Down => walkDownSprites,
                    WatchingDirection.Left => walkLeftSprites,
                    WatchingDirection.Right => walkRightSprites,
                    _ => walkDownSprites
                };
                GetComponent<SpriteRenderer>().sprite = idleSprites[0];
            }
        }
       
        lastPlayerPosition = player.position;
    }

    private bool IsWalkable(Vector3 direction)
{
    // Cast une petite ligne pour vérifier s’il y a un obstacle devant
    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0.3f, Layers.i.SolidLayer);
    return hit.collider == null;
}


    private void UpdateDirection(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            currentDirection = direction.x > 0 ? WatchingDirection.Right : WatchingDirection.Left;
        }
        else
        {
            currentDirection = direction.y > 0 ? WatchingDirection.Up : WatchingDirection.Down;
        }
    }

    private void SitDown()
    {
        if (animator != null)
        {
            animator.HorizontalInput = 0;
            animator.VerticalInput = 0;
            animator.IsCharacterMoving = false;
        }

        isSitting = true;
        Sprite sitSprite = currentDirection switch
        {
            WatchingDirection.Up => sitUpSprites[0],
            WatchingDirection.Down => sitDownSprites[0],
            WatchingDirection.Left => sitLeftSprites[0],
            WatchingDirection.Right => sitRightSprites[0],
            _ => sitDownSprites[0]
        };
        GetComponent<SpriteRenderer>().sprite = sitSprite;
    }

    
    private IEnumerator PlayWalkAnimation()
    {
        isAnimating = true;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        List<Sprite> walkSprites = currentDirection switch
        {
            WatchingDirection.Up => walkUpSprites,
            WatchingDirection.Down => walkDownSprites,
            WatchingDirection.Left => walkLeftSprites,
            WatchingDirection.Right => walkRightSprites,
            _ => walkDownSprites
        };

        int index = 0;
        while (!isSitting && Vector2.Distance(transform.position, player.position) > followDistance)
        {
            sr.sprite = walkSprites[index];
            index = (index + 1) % walkSprites.Count;
            yield return new WaitForSeconds(0.15f);
        }

        isAnimating = false;
    }

    
    public void ResetStateAfterTP()
{
    idleTimer = 0f;
    isSitting = false;
    lastPlayerPosition = player.position;
}
}

