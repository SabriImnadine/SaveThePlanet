using System.Collections.Generic;
using System.Collections;

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

    public IEnumerator PlayStepByStep()
{
    for (int i = 0; i < frameList.Count; i++)
    {
        renderer.sprite = frameList[i];
        yield return new WaitForSeconds(speed);
    }
}


    public Sprite FirstFrame => frameList[0];
    public int FrameCount => frameList.Count;


}

