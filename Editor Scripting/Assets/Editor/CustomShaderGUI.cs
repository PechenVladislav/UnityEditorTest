using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomShaderGUI : ShaderGUI {

    public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {

        MaterialProperty mainTex = FindProperty("_MainTex", properties);
        MaterialProperty useColor = FindProperty("_UseColor", properties);

        materialEditor.ShaderProperty(mainTex, mainTex.displayName);
        materialEditor.ShaderProperty(useColor, useColor.displayName);

        if(useColor.floatValue == 1)
        {
            MaterialProperty colorProp = FindProperty("_Color", properties);
            materialEditor.ShaderProperty(colorProp, colorProp.displayName);
        }
    }
}
