using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void HideOptions()
    {
        optionsPanel.SetActive(false);
    }
}
