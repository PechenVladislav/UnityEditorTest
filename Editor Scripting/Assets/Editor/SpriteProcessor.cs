using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteProcessor : AssetPostprocessor {

	void OnPostprocessTexture(Texture2D texture)  //called any time a texture was imported(OnPreprocessorTexture - called before a texture was imported)
    {
        string lowerCaseAssetPass = assetPath.ToLower(); //where in our project this asset is located once it's been imported
        bool isInSpritesDirectory = lowerCaseAssetPass.IndexOf("/sprites/") != -1;

        if(isInSpritesDirectory)
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
        }
    }
}
