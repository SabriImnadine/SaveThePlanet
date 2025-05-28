using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CutScene))]
public class CutsceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var cutscene = target as CutScene;

        if (GUILayout.Button("Add Action Dialog"))
            cutscene.addAction(new ActionDialog()); 

        if (GUILayout.Button("Add Action Move"))
            cutscene.addAction(new ActionMoving()); 
         if (GUILayout.Button("Add Turn Action"))
            cutscene.addAction(new TurnAction()); 

          serializedObject.Update();
        DrawDefaultInspector();
        serializedObject.ApplyModifiedProperties();
    }
}
