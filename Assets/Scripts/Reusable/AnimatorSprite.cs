using System.Collections.Generic;
using UnityEngine;

public class AnimatorSprite
{
    private SpriteRenderer renderer;
    private List<Sprite> frameList;
    private float speed;

    private int currentIndex;
    private float elapsed;

    public AnimatorSprite(List<Sprite> frames, SpriteRenderer targetRenderer, float frameSpeed = 0.15f)
    {
        frameList = frames;
        renderer = targetRenderer;
        speed = frameSpeed;
    }

    public void Start()
    {
        currentIndex = 0;
        elapsed = 0f;
        renderer.sprite = frameList[0];
    }

    public void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed > speed)
        {
            currentIndex = (currentIndex + 1) % frameList.Count;
            renderer.sprite = frameList[currentIndex];
            elapsed -= speed;
        }
    }

    public Sprite FirstFrame => frameList[0];

}

