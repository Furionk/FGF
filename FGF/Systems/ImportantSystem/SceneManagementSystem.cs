// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: SceneManagementSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 05 - 0:16

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UniRx;

/// <summary>
/// separate which scene type using different sort of subsystem
/// </summary>
public class SceneManagementSystem : ReactiveSystem {
	#region Constants

	public static Dictionary<string, object> SceneLoadingParameter = new Dictionary<string, object>();

	#endregion

	#region Fields

	private Context CTX;
	private SceneLoader _sceneLoader;

	#endregion

	public static void LoadScene(SceneConfig.SceneType sceneType, string sceneName) {
		Contexts.sharedInstance.core.ReplaceSceneConfig(sceneType, sceneName);
	}

	public static void LoadScene(SceneConfig.SceneType sceneType, string sceneName, string transitionScene) {
		Contexts.sharedInstance.core.ReplaceSceneConfig(sceneType, sceneName);
	}

	private void PlaySceneBGM(SceneConfig.SceneType sceneType) {
		BGMData bgmdata = Resources.LoadAll<BGMData>(AppConstants.ScriptableObjectDataFolder).SingleOrDefault(o => o.SceneType == sceneType);
	    if (bgmdata == null) {
            // you can have your own bgm management setting or no bgm
	        Debug.Log("Cannot find bgm data for the corrsponding scene!");
	    } else {
            SoundManager.Instance.PlayBGM(bgmdata);
        }
	}

	protected override Collector GetTrigger(Context context) {
		return context.CreateCollector(CoreMatcher.SceneConfig, GroupEvent.Added);
	}

	protected override void Execute(List<Entity> entities) {
        // execute Coroutine logic in a monobehaviour
        _sceneLoader.StartCoroutine("LoadScene");

        ////// run subsystems
        ////      var subsystems = CTX.sceneConfig.SceneMapping(CTX.sceneConfig.CurrentSceneType);
        ////      Bootstrapper.Instance.CurrentSceneType = CTX.sceneConfig.CurrentSceneType;
        ////      Bootstrapper.Instance.UpdateSubsystems(subsystems);
        ////      // custom scene change logic
        ////      PlaySceneBGM(CTX.sceneConfig.CurrentSceneType);
        ////Debug.Log("Subsystems for: " + CTX.sceneConfig.CurrentSceneType + " has been loaded.");
    }


    public SceneManagementSystem(Context context, SceneLoader sceneLoader) : base(context) {
		CTX = context;
		_sceneLoader = sceneLoader;
	}

	public SceneManagementSystem(Context context) : base(context) {
		CTX = context;
	}

	public SceneManagementSystem(Collector collector) : base(collector) {
        
	}

	#region implemented abstract members of ReactiveSystem

	protected override bool Filter(Entity entity) {
		return true;
	}

	#endregion
}