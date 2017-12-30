using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadUtility : MonoBehaviour {

    private string _targetScene;

    public void LoadScene(string targetScene) {
        _targetScene = targetScene;
        StartCoroutine("LoadProcess");
    }

    private IEnumerator LoadProcess() {
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(_targetScene, LoadSceneMode.Single);

        yield return this;
    }

}
