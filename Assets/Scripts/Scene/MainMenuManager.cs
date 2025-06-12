using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
    public Fade fade; 
    public string sceneToLoad = "MainScene"; 

    private void Start()
{
        if (fade == null) ;
        else
            StartCoroutine(fade.Hide(1f));
}
    public void StartGame()
    {
        StartCoroutine(StartGameRoutine());
    }

    private IEnumerator StartGameRoutine()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
      GameObject reusable = GameObject.Find("ReusableObjects(Clone)");
    if (reusable != null)
    {
    Destroy(reusable);
    yield return null;
    }

        yield return fade.Show(1f); 
        SceneManager.LoadScene(sceneToLoad); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
