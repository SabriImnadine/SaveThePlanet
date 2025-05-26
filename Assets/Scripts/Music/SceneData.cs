using UnityEngine;

public class SceneData : MonoBehaviour
{
     [SerializeField] private AudioClip sceneMusic;

    public AudioClip GetSceneMusic()
    {
        return sceneMusic;
    }
}
