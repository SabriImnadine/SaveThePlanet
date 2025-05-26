using UnityEngine;
using System.Collections;

public class MusicStarter : MonoBehaviour
{
    IEnumerator Start()
    {
        while (MusicManager.i == null)
            yield return null;

        SceneData details = FindFirstObjectByType<SceneData>();
        if (details != null)
        {
           MusicManager.i.PlayAudio(details.GetSceneMusic(), fade: true);
        }
    }
}
