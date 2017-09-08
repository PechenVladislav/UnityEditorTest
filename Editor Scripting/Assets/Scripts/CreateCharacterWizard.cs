using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateCharacterWizard : ScriptableWizard {

    public Texture2D _portrait;
    public string _nickname;
    public Color _color;

    [MenuItem("My Tools/Create Character Wizard...")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<CreateCharacterWizard>("Create Chracter", "Create New", "Update Selected");
    }

    void OnWizardCreate()
    {
        GameObject characterGO = new GameObject();

        Character characterComponent = characterGO.AddComponent<Character>();
        characterComponent._portrait = _portrait;
        characterComponent._color = _color;
        characterComponent._nickname = _nickname;

        PlayerMovement playerMovement = characterGO.AddComponent<PlayerMovement>();
        characterComponent._playerMovement = playerMovement;
    }

    void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            Character characterComponent = Selection.activeTransform.GetComponent<Character>();
            if(characterComponent != null)
            {
                characterComponent._portrait = _portrait;
                characterComponent._color = _color;
                characterComponent._nickname = _nickname;
            }
        }
    }

    void OnWizardUpdate()
    {
        helpString = "Enter Chatacter Details";
    }
}
