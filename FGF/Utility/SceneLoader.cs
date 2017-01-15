using UnityEngine;
using System.Collections;
using Entitas;

public class SceneLoader : UnityEngine.MonoBehaviour {

    IEnumerator LoadScene() {
        //AsyncOperation async = UnityEngine.SceneManagement.SceneManager.UnloadScene(pPool.sceneConfig.TargetScene);
        Context ctx = Contexts.sharedInstance.core;

        foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadStartListener).GetEntities()) {
            entity.sceneLoadStartListener.Notify(new SceneLoadStartMessage());
        }

        if (!string.IsNullOrEmpty(ctx.sceneConfig.TargetScene)) {
            AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(ctx.sceneConfig.TargetScene);

            while (!async.isDone) {
                Debug.Log("Loading Scene" + ctx.sceneConfig.TargetScene + ":" + async.progress);
                foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadProgressListener).GetEntities()) {
                    entity.sceneLoadProgressListener.Notify(new SceneLoadProgressMessage() {
                        Progress = async.progress
                    });
                }
                yield return new WaitForEndOfFrame();
            }
        }

        // run subsystems
        var subsystems = ctx.sceneConfig.SceneMapping(ctx.sceneConfig.CurrentSceneType);
        Bootstrapper.Instance.CurrentSceneType = ctx.sceneConfig.CurrentSceneType;
        Bootstrapper.Instance.UpdateSubsystems(subsystems);

        foreach (var entity in ctx.GetGroup(CoreMatcher.SceneLoadEndListener).GetEntities()) {
            entity.sceneLoadEndListener.Notify(new SceneLoadEndMessage());
        }

        Debug.Log("Subsystems for: " + ctx.sceneConfig.CurrentSceneType + " has been loaded.");
    }
}
