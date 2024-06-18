using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IndieGameDeveloper
{
    [CustomEditor(typeof(RagdollWizzard))]
    public class SetUpRagdollWizzard : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            RagdollWizzard wizzard = (RagdollWizzard) target;

            if(GUILayout.Button("Setup RagdollParts"))
            {
                wizzard.SetRagdollParts();
            }
        }
    }
}
