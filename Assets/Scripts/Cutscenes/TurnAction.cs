using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAction : CutsceneAction
{
    [SerializeField] CutsceneActor actor;
    [SerializeField] WatchingDirection direction;

    public override IEnumerator Play()
    {
        actor.GetCharacter().Animator.setWatchingDirection(direction);
        yield break;
    }
}
