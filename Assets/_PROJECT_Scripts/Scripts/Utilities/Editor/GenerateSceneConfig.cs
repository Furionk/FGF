using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GenerateSceneConfig : AssetPostprocessor {

    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths) {
        var file = AssetDatabase.FindAssets("ScseneSettings");
        Debug.Log(file == null);
    }
}