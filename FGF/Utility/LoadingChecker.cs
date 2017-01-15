// Solution Name: FGF
// Project: FGF
// File: LoadingChecker.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingChecker : MonoBehaviour {
    private void Awake() {
        Debug.Log(string.Format("{0} is awake", SceneManager.GetActiveScene().name));
    }

    // Use this for initialization
    private void Start() {
        Debug.Log(string.Format("{0} is start", SceneManager.GetActiveScene().name));
    }
}