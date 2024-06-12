using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IndieGameDeveloper
{
    [CustomEditor(typeof(CharacterControl))]
    public class ChangeMaterial : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CharacterControl player = (CharacterControl)target;

            if (GUILayout.Button("Change Material"))
            {
                player.ChangeMaterial();
            }
        }
    }
}
