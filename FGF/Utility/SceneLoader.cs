using UnityEngine;
using System.Collections;
using Entitas;

public class SceneLoader : UnityEngine.MonoBehaviour {

    IEnumerator LoadScene() {
        //AsyncOperation async = UnityEngine.SceneManagement.SceneManager.UnloadScene(pPool.sceneConfig.TargetScene);
        AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(Contexts.sharedInstance.core.sceneConfig.TargetScene);

        foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadStartListener).GetEntities()) {
            entity.sceneLoadStartListener.Notify(new SceneLoadStartMessage());
        }

        while (!async.isDone) {
            Debug.Log("Loading Scene" + Contexts.sharedInstance.core.sceneConfig.TargetScene + ":" + async.progress);
            foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadProgressListener).GetEntities()) {
                entity.sceneLoadProgressListener.Notify(new SceneLoadProgressMessage() {
                    Progress = async.progress
                });
            }
            yield return new WaitForEndOfFrame();
        }

        foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadEndListener).GetEntities()) {
            entity.sceneLoadEndListener.Notify(new SceneLoadEndMessage());
        }
    }
}
