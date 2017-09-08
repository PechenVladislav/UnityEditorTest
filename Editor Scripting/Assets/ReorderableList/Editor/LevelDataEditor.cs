using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor {

    private ReorderableList list;

    private void OnEnable()
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("m_Waves"));
        list.drawElementCallback = DrawList;
        list.drawHeaderCallback = DrawHead;
        list.onSelectCallback = SelectItem;
        list.onCanRemoveCallback = CanRemove;
        list.onRemoveCallback = RemoveItem;
    }

    private void RemoveItem(ReorderableList list)
    {
        if(EditorUtility.DisplayDialog("Warning!", "Are you sure you want to delete the wave?", "Yes!", "No"))
        {
            ReorderableList.defaultBehaviours.DoRemoveButton(list);
        }
    }

    private bool CanRemove(ReorderableList list)
    {
        return list.count > 1;
    }

    private void SelectItem(ReorderableList list)
    {
        GameObject prefab = list.serializedProperty.GetArrayElementAtIndex(list.index).FindPropertyRelative("m_Prefab").objectReferenceValue as GameObject;
        if(prefab != null)
        {
            EditorGUIUtility.PingObject(prefab.GetInstanceID());
        }
    }

    private void DrawHead(Rect rect)
    {
        EditorGUI.LabelField(rect, "Waves of Monsters");
    }

    private void DrawList(Rect rect, int index, bool isActive, bool isFocused)
    {
        SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
        rect.y += 2f;
        EditorGUI.PropertyField(new Rect(rect.x, rect.y, 60f, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("m_Type"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(rect.x + 60f, rect.y, rect.width - 60f - 30f, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("m_Prefab"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(rect.x + rect.width - 30f, rect.y, 30f, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("m_Count"), GUIContent.none);

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
