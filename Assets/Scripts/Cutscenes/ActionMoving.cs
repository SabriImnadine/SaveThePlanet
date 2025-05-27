using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionMoving : CutsceneAction
{
    public Character character;
    public List<Vector2> movePatterns;

    public override IEnumerator Play()
    {
        character.UseInternalHandleUpdate = true;
        foreach (var moveVec in movePatterns)
        {
            yield return character.Move(moveVec);
        }
        
    character.UseInternalHandleUpdate = false;
    }
}
