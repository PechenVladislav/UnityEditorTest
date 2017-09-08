using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Camera))]
public class CameraEditor : Editor
{

    public override void OnInspectorGUI()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;

        GUILayout.Label("<size=25> This is <color=red>RED</color></size>", style);

        base.OnInspectorGUI();
    }

}