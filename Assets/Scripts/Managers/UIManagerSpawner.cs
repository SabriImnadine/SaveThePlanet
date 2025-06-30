using UnityEngine;

public class UIManagerSpawner : MonoBehaviour
{
    public GameObject uiPrefab;
    private static bool hasSpawned = false;

    void Awake()
    {
        if (!hasSpawned)
    {
    GameObject uiInstance = Instantiate(uiPrefab);
    DontDestroyOnLoad(uiInstance); 
    hasSpawned = true;
    }

    }
}
