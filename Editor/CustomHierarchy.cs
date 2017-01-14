// Solution Name: Area.Entitia
// Project: Area.Entitia.Editor
// File: CustomHierarchy.cs
// 
// By: Furion
// Last Pinned Datetime: 2016 / 12 / 09 - 1:34

using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

[InitializeOnLoad]
public class CustomHierarchy {
    #region Constants
    private static readonly Texture2D iMono;
    private static readonly Texture2D iAnimator;
    private static readonly Texture2D iMainCamera;
    private static readonly Texture2D iMonoBehaviour;
    private static readonly List<int> gMono = new List<int>();
    private static readonly List<int> gAnimator = new List<int>();
    private static readonly List<int> gMainCamera = new List<int>();
    private static readonly List<int> gMonoBehaviour = new List<int>();
    #endregion

    static CustomHierarchy() {
        iMono = AssetDatabase.LoadAssetAtPath("Assets/Area.Sources/Icon.Mono.psd", typeof(Texture2D)) as Texture2D;
        iAnimator = AssetDatabase.LoadAssetAtPath("Assets/Area.Sources/Icon.Animator.psd", typeof(Texture2D)) as Texture2D;
        iMainCamera = AssetDatabase.LoadAssetAtPath("Assets/Area.Sources/Icon.MainCamera.psd", typeof(Texture2D)) as Texture2D;
        iMonoBehaviour = AssetDatabase.LoadAssetAtPath("Assets/Area.Sources/Icon.MonoBehaviour.psd", typeof(Texture2D)) as Texture2D;
        EditorApplication.hierarchyWindowChanged += Update;
        EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyItemIcon;
    }

    private static void Update() {
        gMono.Clear();
        gAnimator.Clear();
        gMainCamera.Clear();
        gMonoBehaviour.Clear();
        GameObject[] go = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject g in go) {
            if (g == null) continue;
            int instanceId = g.GetInstanceID();
            if (g.GetComponent<EntityBehaviour>() != null)
                gMono.Add(instanceId);
            if (g.tag == "MainCamera")
                gMainCamera.Add(instanceId);
            if (g.GetComponent<Animator>() != null)
                gAnimator.Add(instanceId);
            if (g.GetComponent<MonoBehaviour>() != null) {
                Type type = g.GetComponent<MonoBehaviour>().GetType();
                if (!string.IsNullOrEmpty(type.Namespace)) {
                    if (!type.Namespace.Contains("UnityEngine")) {
                        gMonoBehaviour.Add(instanceId);
                    }
                }
            }
        }
    }

    private static void DrawHierarchyItemIcon(int instanceId, Rect selectionRect) {
        Rect r = new Rect(selectionRect);
        r.x += r.width - 24;
        if (gMonoBehaviour.Contains(instanceId)) {
            r.x -= 10;
            r.width = 17;
            GUI.Label(r, iMonoBehaviour);
        }
        if (gMono.Contains(instanceId)) {
            r.x -= 52;
            r.width = 64;
            GUI.Label(r, iMono);
        }
        if (gMainCamera.Contains(instanceId)) {
            r.x -= 52;
            r.width = 64;
            GUI.Label(r, iMainCamera);
        }
        if (gAnimator.Contains(instanceId)) {
            r.x -= 52;
            r.width = 64;
            GUI.Label(r, iAnimator);
        }
    }
}