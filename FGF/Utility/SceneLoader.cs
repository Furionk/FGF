// Solution Name: FGF
// Project: FGF
// File: SceneLoader.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System.Collections;
using Entitas;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    private IEnumerator LoadScene() {
        var ctx = Contexts.sharedInstance.core;

        // before scene loaded
        foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadStartListener).GetEntities()) {
            entity.sceneLoadStartListener.Notify(new SceneLoadStartMessage());
        }
        if (!string.IsNullOrEmpty(ctx.sceneConfig.TargetScene)) {
            var async = SceneManager.LoadSceneAsync(ctx.sceneConfig.TargetScene);
            while (!async.isDone) {
                //Debug.Log("Loading Scene" + ctx.sceneConfig.TargetScene + ":" + async.progress);

                foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadProgressListener).GetEntities()) {
                    entity.sceneLoadProgressListener.Notify(new SceneLoadProgressMessage {
                        Progress = async.progress
                    });
                }
                yield return new WaitForEndOfFrame();
            }
        }

        // after scene loaded
        EntityBehaviour[] entityEntityBehaviours = FindObjectsOfType<EntityBehaviour>();

        // run subsystems
        var subsystems = ctx.sceneConfig.SceneMapping(ctx.sceneConfig.CurrentSceneType);
        Bootstrapper.Instance.CurrentSceneType = ctx.sceneConfig.CurrentSceneType;
        Bootstrapper.Instance.UpdateSubsystems(subsystems);

        foreach (var entityEntityBehaviour in entityEntityBehaviours) {
            entityEntityBehaviour.Initialize();
        }

        foreach (var entityEntityBehaviour in entityEntityBehaviours) {
            entityEntityBehaviour.AfterInitialized();
        }

        foreach (var entity in ctx.GetGroup(CoreMatcher.SceneLoadEndListener).GetEntities()) {
            entity.sceneLoadEndListener.Notify(new SceneLoadEndMessage());
        }

        //Debug.Log("Subsystems for: " + ctx.sceneConfig.CurrentSceneType + " has been loaded.");
    }
}