using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public QuestData lightQuest; 

    private void Start()
{
#if UNITY_EDITOR
    if (!PlayerPrefs.HasKey("DevResetDone"))
    {
        PlayerPrefs.DeleteAll(); // Supprime tout
        PlayerPrefs.SetInt("DevResetDone", 1); // Flag pour ne pas re-reset
        PlayerPrefs.Save();
        Debug.Log("🧼 Reset effectué une seule fois.");
    }
#endif
}


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


