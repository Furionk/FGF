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
        var currentSceneName = SceneManager.GetActiveScene().name;

        // before scene loaded
        foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadStartListener).GetEntities()) {
            entity.sceneLoadStartListener.Notify(new SceneLoadStartMessage());
        }
        if (!string.IsNullOrEmpty(ctx.sceneConfig.TargetScene)) {
            var loadOperation = SceneManager.LoadSceneAsync(ctx.sceneConfig.TargetScene);
            while (!loadOperation.isDone) {
                //Debug.Log("Loading Scene" + ctx.sceneConfig.TargetScene + ":" + async.progress);
                foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadProgressListener).GetEntities()) {
                    entity.sceneLoadProgressListener.Notify(new SceneLoadProgressMessage {
                        Type = SceneLoadProgressMessage.SceneLoadProgressType.UnityScenePart,
                        Progress = loadOperation.progress
                    });
                }
                yield return new WaitForEndOfFrame();
            }
        }

        // after scene loaded
        var entityEntityBehaviours = FindObjectsOfType<CustomEntityBehaviour>();
        float eneitaLoading = 0;
        float entitaLoadingCount = entityEntityBehaviours.Length;

        // run subsystems
        Bootstrapper.Instance.UpdateSubsystems(ctx.sceneConfig.CurrentSceneType, ctx.sceneConfig.SceneMapping(ctx.sceneConfig.CurrentSceneType));
        foreach (var entityEntityBehaviour in entityEntityBehaviours) {
            entityEntityBehaviour.Initialize();
            eneitaLoading++;
            foreach (var entity in Contexts.sharedInstance.core.GetGroup(CoreMatcher.SceneLoadProgressListener).GetEntities()) {
                entity.sceneLoadProgressListener.Notify(new SceneLoadProgressMessage {
                    Type = SceneLoadProgressMessage.SceneLoadProgressType.EntitasPart,
                    Progress = eneitaLoading/entitaLoadingCount
                });
            }
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