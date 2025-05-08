using System.Collections.Generic;
using UnityEngine;

public class AnimatorCharacter : MonoBehaviour
{
    [SerializeField] private List<Sprite> downSprites;
    [SerializeField] private List<Sprite> upSprites;
    [SerializeField] private List<Sprite> rightSprites;
    [SerializeField] private List<Sprite> leftSprites;

    public float HorizontalInput { get; set; }
    public float VerticalInput { get; set; }
    public bool IsCharacterMoving { get; set; }

    private AnimatorSprite downAnim;
    private AnimatorSprite upAnim;
    private AnimatorSprite rightAnim;
    private AnimatorSprite leftAnim;

    private AnimatorSprite currentAnim;
    private SpriteRenderer spriteRenderer;
    bool wasMovingPreviously;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        downAnim = new AnimatorSprite(downSprites, spriteRenderer);
        upAnim = new AnimatorSprite(upSprites, spriteRenderer);
        rightAnim = new AnimatorSprite(rightSprites, spriteRenderer);
        leftAnim = new AnimatorSprite(leftSprites, spriteRenderer);

        currentAnim = downAnim;
    }

    private void Update()
    {
        var previousAnim = currentAnim;

        if (HorizontalInput == 1)
            currentAnim = rightAnim;
        else if (HorizontalInput == -1)
            currentAnim = leftAnim;
        else if (VerticalInput == 1)
            currentAnim = upAnim;
        else if (VerticalInput == -1)
            currentAnim = downAnim;

        if (currentAnim != previousAnim || IsCharacterMoving != wasMovingPreviously)
            currentAnim.Start();

        if (IsCharacterMoving)
            currentAnim.Update();
        else
            spriteRenderer.sprite = currentAnim.FirstFrame;

        wasMovingPreviously = IsCharacterMoving;    
    }
}

