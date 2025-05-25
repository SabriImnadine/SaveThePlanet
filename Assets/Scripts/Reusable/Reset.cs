using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private bool resetAtStart = true;

    private void Awake()
    {
#if UNITY_EDITOR
        if (resetAtStart)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("🧼 Tous les PlayerPrefs ont été reset.");
        }
#endif
    }
}
