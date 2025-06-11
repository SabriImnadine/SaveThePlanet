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

        if (PlayerPrefs.GetInt("MayorMission_acknowledged", 0) == 0)
        {
            Instantiate(mayorPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
