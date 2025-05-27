using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class CutsceneAction

{
    [SerializeField] string name;

    public  virtual IEnumerator Play()
    {
        yield break;
    }
}
