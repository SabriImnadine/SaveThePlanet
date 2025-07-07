using UnityEngine;
using TMPro;

public class StatsUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text co2Text;
    [SerializeField] private TMP_Text electricityText;
    [SerializeField] private TMP_Text plasticText;

    void Update()
    {
        if (GameStatsManager.Instance == null) return;

        co2Text.text = "🌱 CO₂-vervuiling: " + GameStatsManager.Instance.Co2Level + "%";
        electricityText.text = "⚡ Elektriciteitsverspilling: " + GameStatsManager.Instance.ElectricityWaste + "%";
        plasticText.text = "🧴 Plasticvervuiling: " + GameStatsManager.Instance.PlasticPollution + "%";
    }
}
