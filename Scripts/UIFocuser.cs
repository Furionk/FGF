using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public class UIFocuser : MonoBehaviour {

    [MenuItem("View Utility/2D Mode %f")]
    static void Focus() {
        Assert.IsNotNull(SceneView.lastActiveSceneView);
        if (SceneView.lastActiveSceneView != null) {
            SceneView.lastActiveSceneView.in2DMode = !SceneView.lastActiveSceneView.in2DMode;

            if (SceneView.lastActiveSceneView.in2DMode) {
                SceneView.lastActiveSceneView.AlignViewToObject(GameObject.FindObjectOfType<Canvas>().GetComponent<RectTransform>());
            } else {

                
            }
            
        }
    }
	
}
