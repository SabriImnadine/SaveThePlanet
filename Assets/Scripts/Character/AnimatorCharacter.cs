using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AnimatorCharacter : MonoBehaviour
{
    [SerializeField] private List<Sprite> downSprites;
    [SerializeField] private List<Sprite> upSprites;
    [SerializeField] private List<Sprite> rightSprites;
    [SerializeField] private List<Sprite> leftSprites;
    [SerializeField] WatchingDirection defaultDirection = WatchingDirection.Down;

    [SerializeField] private List<Sprite> digDownSprites;
    [SerializeField] private List<Sprite> digUpSprites;
    [SerializeField] private List<Sprite> digLeftSprites;
    [SerializeField] private List<Sprite> digRightSprites;

    [SerializeField] private List<Sprite> plantDownSprites;
    [SerializeField] private List<Sprite> plantUpSprites;
    [SerializeField] private List<Sprite> plantLeftSprites;
    [SerializeField] private List<Sprite> plantRightSprites;

    [SerializeField] private List<Sprite> pickupDownSprites;
    [SerializeField] private List<Sprite> pickupUpSprites;
    [SerializeField] private List<Sprite> pickupLeftSprites;
    [SerializeField] private List<Sprite> pickupRightSprites;




    public float HorizontalInput { get; set; }
    public float VerticalInput { get; set; }
    public bool IsCharacterMoving { get; set; }

    
    private AnimatorSprite digDownAnim;
    private AnimatorSprite digUpAnim;
    private AnimatorSprite digLeftAnim;
    private AnimatorSprite digRightAnim;
    private AnimatorSprite downAnim;
    private AnimatorSprite upAnim;
    private AnimatorSprite rightAnim;
    private AnimatorSprite leftAnim;
    private AnimatorSprite plantDownAnim;
    private AnimatorSprite plantUpAnim;
    private AnimatorSprite plantLeftAnim;
    private AnimatorSprite plantRightAnim;
    private AnimatorSprite pickupDownAnim;
    private AnimatorSprite pickupUpAnim;
    private AnimatorSprite pickupLeftAnim;
    private AnimatorSprite pickupRightAnim;

    private AnimatorSprite currentAnim;
    private SpriteRenderer spriteRenderer;
    bool wasMovingPreviously;
    private bool isPlayingSpecialAnimation = false;
    private WatchingDirection lastDirection;

    public WatchingDirection ViewDirection => lastDirection;



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        plantDownAnim = new AnimatorSprite(plantDownSprites, spriteRenderer);
        plantUpAnim = new AnimatorSprite(plantUpSprites, spriteRenderer);
        plantLeftAnim = new AnimatorSprite(plantLeftSprites, spriteRenderer);
        plantRightAnim = new AnimatorSprite(plantRightSprites, spriteRenderer);

        pickupDownAnim = new AnimatorSprite(pickupDownSprites, spriteRenderer);
        pickupUpAnim = new AnimatorSprite(pickupUpSprites, spriteRenderer);
        pickupLeftAnim = new AnimatorSprite(pickupLeftSprites, spriteRenderer);
        pickupRightAnim = new AnimatorSprite(pickupRightSprites, spriteRenderer);


        

        digDownAnim = new AnimatorSprite(digDownSprites, spriteRenderer);
        digUpAnim = new AnimatorSprite(digUpSprites, spriteRenderer);
        digLeftAnim = new AnimatorSprite(digLeftSprites, spriteRenderer);
        digRightAnim = new AnimatorSprite(digRightSprites, spriteRenderer);


        downAnim = new AnimatorSprite(downSprites, spriteRenderer);
        upAnim = new AnimatorSprite(upSprites, spriteRenderer);
        rightAnim = new AnimatorSprite(rightSprites, spriteRenderer);
        leftAnim = new AnimatorSprite(leftSprites, spriteRenderer);
        setWatchingDirection(defaultDirection);

        currentAnim = downAnim;
    }

    public IEnumerator PlayDigAnimation(WatchingDirection direction)
    {
        isPlayingSpecialAnimation = true;

        AnimatorSprite digAnim = direction switch
        {
            WatchingDirection.Up => digUpAnim,
            WatchingDirection.Down => digDownAnim,
            WatchingDirection.Left => digLeftAnim,
            WatchingDirection.Right => digRightAnim,
            _ => digDownAnim
        };

        yield return digAnim.PlayStepByStep();

        spriteRenderer.sprite = digAnim.FirstFrame;

        yield return new WaitForSeconds(0.1f);

        isPlayingSpecialAnimation = false;
    }

public IEnumerator PlayPlantAnimation(WatchingDirection direction)
{
    isPlayingSpecialAnimation = true;

    AnimatorSprite plantAnim = direction switch
    {
        WatchingDirection.Up => plantUpAnim,
        WatchingDirection.Down => plantDownAnim,
        WatchingDirection.Left => plantLeftAnim,
        WatchingDirection.Right => plantRightAnim,
        _ => plantDownAnim
    };

    yield return plantAnim.PlayStepByStep();

    spriteRenderer.sprite = plantAnim.FirstFrame;

    yield return new WaitForSeconds(0.1f);

    isPlayingSpecialAnimation = false;
}

    public IEnumerator PlayPickupAnimation(WatchingDirection direction)
    {
    isPlayingSpecialAnimation = true;

    AnimatorSprite pickupAnim = direction switch
    {
        WatchingDirection.Up => pickupUpAnim,
        WatchingDirection.Down => pickupDownAnim,
        WatchingDirection.Left => pickupLeftAnim,
        WatchingDirection.Right => pickupRightAnim,
        _ => pickupDownAnim
    };

    yield return pickupAnim.PlayStepByStep();

    spriteRenderer.sprite = pickupAnim.FirstFrame;

    yield return new WaitForSeconds(0.1f);

    isPlayingSpecialAnimation = false;
    }



    private void Update()
    {
        if (isPlayingSpecialAnimation)
            return;

        var previousAnim = currentAnim;

        if (HorizontalInput == 1)
        {
            currentAnim = rightAnim;
            lastDirection = WatchingDirection.Right;
        }
        else if (HorizontalInput == -1)
        {
            currentAnim = leftAnim;
            lastDirection = WatchingDirection.Left;
        }
        else if (VerticalInput == 1)
        {
            currentAnim = upAnim;
            lastDirection = WatchingDirection.Up;
        }
        else if (VerticalInput == -1)
        {
            currentAnim = downAnim;
            lastDirection = WatchingDirection.Down;
        }


        if (currentAnim != previousAnim || IsCharacterMoving != wasMovingPreviously)
            currentAnim.Start();

        if (IsCharacterMoving)
            currentAnim.Update();
        else
            spriteRenderer.sprite = currentAnim.FirstFrame;

        wasMovingPreviously = IsCharacterMoving;
    }
    public void setWatchingDirection(WatchingDirection dir)
{
    currentDirection = dir;

    if (dir == WatchingDirection.Right)
    {
        HorizontalInput = 1;
        VerticalInput = 0;
    }
    else if (dir == WatchingDirection.Left)
    {
        HorizontalInput = -1;
        VerticalInput = 0;
    }
    else if (dir == WatchingDirection.Up)
    {
        VerticalInput = 1;
        HorizontalInput = 0;
    }
    else if (dir == WatchingDirection.Down)
    {
        VerticalInput = -1;
        HorizontalInput = 0;
    }
}

  private WatchingDirection currentDirection;


}
public enum WatchingDirection { Up, Down, Left, Right}
