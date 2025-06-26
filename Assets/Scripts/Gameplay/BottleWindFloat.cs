using UnityEngine;

public class BottleWindFloat : MonoBehaviour
{
    public float amplitude = 0.07f;  
    public float frequency = 0.8f;  
    public float offset = 0f;        

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        offset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time * frequency + offset) * amplitude;
        transform.position = startPos + new Vector3(movement, 0f, 0f);
    }
}
