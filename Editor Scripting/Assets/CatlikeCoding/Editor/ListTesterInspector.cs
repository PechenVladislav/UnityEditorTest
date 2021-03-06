﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ListTester))]
public class ListTesterInspector : Editor {

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("integers"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("vectors"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("colorPoints"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("objects"));
        serializedObject.ApplyModifiedProperties();
    }
}
