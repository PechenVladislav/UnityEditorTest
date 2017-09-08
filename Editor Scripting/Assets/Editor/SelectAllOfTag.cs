using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelectAllOfTag : ScriptableWizard {

    public string _searchTag = "Your Tag Here";

    [MenuItem("My Tools/Sellect All Of Tag...")]
	static void SelectAllOfTagWizard()
    {
        ScriptableWizard.DisplayWizard<SelectAllOfTag>("Select All Of Tag...", "Make Selection");
    }

    void OnWizardCreate()
    {
        GameObject[] gameObjects;
        try {
            gameObjects = GameObject.FindGameObjectsWithTag(_searchTag);
        }
        catch (UnityException e)
        {
            return;
        }
        Selection.objects = gameObjects;
    }
}
