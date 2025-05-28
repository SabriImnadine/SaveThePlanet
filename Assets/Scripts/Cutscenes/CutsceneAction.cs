using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class CutsceneAction
{
    [SerializeField] string name;
    [SerializeField] private bool waitForCompletion = true;

    public virtual IEnumerator Play()
    {
        yield break;
    }

    public bool WaitsForCompletion => waitForCompletion;
}
