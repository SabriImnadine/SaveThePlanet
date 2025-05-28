using System.Collections;
using UnityEngine;

[System.Serializable]
public class ActionDialog : CutsceneAction
{
    public Dialog dialog;

    public override IEnumerator Play()
    {
        bool dialogFinished = false;

        
        yield return DialogManager.Instance.Showdialog(dialog, () => {
            dialogFinished = true;
        });

   
        while (!dialogFinished)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogManager.Instance.HandleUpdate();
            }

            yield return null;
        }
    }
}
