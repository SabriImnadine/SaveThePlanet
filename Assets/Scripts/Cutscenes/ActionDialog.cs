using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionDialog : CutsceneAction
{
    public Dialog dialog;

    public override IEnumerator Play()
    {
        yield return DialogManager.Instance.Showdialog(dialog);
    }
}
