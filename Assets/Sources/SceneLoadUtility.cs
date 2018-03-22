// FGF - FGF - SceneLoadUtility.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 03 22 下午 11:42
// By: Furion Mashiou

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadUtility : MonoBehaviour {

    #region Methods

    public void Awake() {
        StartCoroutine("DirectLoad", SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string targetScene) {
        StartCoroutine("LoadProcess", targetScene);
    }

    public IEnumerator PreProcess(string targetScene) {
        Debug.Log("PRE process " + targetScene);
        yield return null;
    }

    public void AfterProcess(string targetScene) {
        Debug.Log("AFT process " + targetScene);
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

    #endregion

}