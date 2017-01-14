using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingChecker : MonoBehaviour {

    void Awake() {
        Debug.Log(string.Format("{0} is awake", SceneManager.GetActiveScene().name));
    }

	// Use this for initialization
	void Start () {
        Debug.Log(string.Format("{0} is start", SceneManager.GetActiveScene().name));
    }
	
}
