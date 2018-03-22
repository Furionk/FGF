using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoadUtility : MonoBehaviour {

    public void Awake() {
        StartCoroutine("DirectLoad", SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string targetScene) {
        StartCoroutine("LoadProcess", targetScene);
    }

    private IEnumerator LoadProcess(string targetScene) {
        var activeSceneName = SceneManager.GetActiveScene().name;
        var async1          = SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Single);
        while (!async1.isDone) {
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        var async2 = SceneManager.LoadSceneAsync(targetScene, LoadSceneMode.Additive);
        yield return PreProcess(targetScene);
        while (!async2.isDone) {
            yield return null;
        }
        yield return new WaitForSeconds(2f);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(targetScene));
        var async3 = SceneManager.UnloadSceneAsync("Loading");
        while (!async3.isDone) {
            yield return null;
        }
        yield return null;
        AfterProcess(targetScene);
    }

    private IEnumerator DirectLoad(string targetScene) {
        yield return PreProcess(targetScene);
        AfterProcess(targetScene);
        yield return null;
    }

    public IEnumerator PreProcess(string targetScene) {
        Debug.Log("PRE process " + targetScene);
        yield return null;
    }

    public void AfterProcess(string targetScene) {
        Debug.Log("AFT process " + targetScene);
    }

}
