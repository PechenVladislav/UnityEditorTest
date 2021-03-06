﻿using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ColorPoint))]
public class ColorPointDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        Rect contentPosition = EditorGUI.PrefixLabel(position, label);
        if(position.height > 16f)
        {
            position.height = 16f;
            EditorGUI.indentLevel += 1;
            contentPosition = EditorGUI.IndentedRect(position); //not found on Scripting API!!!
            contentPosition.y += 18f;
        }
        contentPosition.width *= 0.75f;
        EditorGUI.indentLevel = 0;
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("position"), GUIContent.none);
        contentPosition.x += contentPosition.width;
        contentPosition.width /= 3f;
        EditorGUIUtility.labelWidth = 14f;
        EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("color"), new GUIContent("C"));
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return Screen.width < 333 ? (16f + 18f) : 16f;
    }
}
