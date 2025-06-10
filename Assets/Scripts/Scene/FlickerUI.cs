using UnityEngine;

public class FlickerUI : MonoBehaviour
{
    public GameObject controlsUI;
    public float flickerInterval = 0.5f;
    public float displayDuration = 5f;
    public float startDelay = 1f;

    private float timer = 0f;
    private float flickerTimer = 0f;
    private float delayTimer = 0f;
    private bool hasStarted = false;
    private bool isVisible = true;

    void Update()
    {
        if (!hasStarted)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= startDelay)
            {
                controlsUI.SetActive(true);
                hasStarted = true;
            }
            return;
        }

        timer += Time.deltaTime;
        flickerTimer += Time.deltaTime;

        if (flickerTimer >= flickerInterval)
        {
            isVisible = !isVisible;
            controlsUI.SetActive(isVisible);
            flickerTimer = 0f;
        }

        if (timer >= displayDuration)
        {
            controlsUI.SetActive(false);
            Destroy(this);
        }
    }
}
