using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionMoving : CutsceneAction
{
    public CutsceneActor actor;
    public List<Vector2> movePatterns;

    public override IEnumerator Play()
    {
        var character = actor.GetCharacter();

        character.UseInternalHandleUpdate = true;
        foreach (var moveVec in movePatterns)
        {
            yield return character.Move(moveVec, checkCollisions: false);
        }

        character.UseInternalHandleUpdate = false;
    }
}
[System.Serializable]
public class CutsceneActor
{
    [SerializeField] bool isPlayer;
    [SerializeField] Character character;

    public Character GetCharacter() => (isPlayer) ? PlayerController.i.Character : character;
}
