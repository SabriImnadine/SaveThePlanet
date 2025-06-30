using UnityEngine;

public class GameStatsManager : MonoBehaviour
{
    public static GameStatsManager Instance;

    [Header("Milieu Scorewaarden")]
    public int Co2Level = 100;
    public int ElectricityWaste = 100;
    public int PlasticPollution = 100;

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

  public void ReduceElectricityWaste(int amount)
{
    ElectricityWaste = Mathf.Max(0, ElectricityWaste - amount);
    Debug.Log("Electricity Waste reduced to: " + ElectricityWaste);
}

public void ReduceCO2(int amount)
{
    Co2Level = Mathf.Max(0, Co2Level - amount);
    Debug.Log("CO2 Level reduced to: " + Co2Level);
}

public void ReducePlasticPollution(int amount)
{
    PlasticPollution = Mathf.Max(0, PlasticPollution - amount);
    Debug.Log("Plastic Pollution reduced to: " + PlasticPollution);
}

}
