using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject mayorPrefab;     
    public Transform spawnPoint;        

    void Start()
    {
        GameObject oldMayor = GameObject.FindWithTag("Mayor");
        if (oldMayor != null)
        {
            Destroy(oldMayor);
        }

        int acknowledged = PlayerPrefs.GetInt("LightQuest_acknowledged", 0);

        if (acknowledged == 0)
        {
            Instantiate(mayorPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
