// Solution Name: FGF
// Project: FGF
// File: SceneManagementSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System.Collections.Generic;
using Entitas;

/// <summary>
///     separate which scene type using different sort of subsystem
/// </summary>
public class SceneManagementSystem : ReactiveSystem {
    #region Constants
    public static Dictionary<string, object> SceneLoadingParameter = new Dictionary<string, object>();
    #endregion

    #region Fields
    private readonly SceneLoader _sceneLoader;
    private Context CTX;
    #endregion

    public SceneManagementSystem(Context context, SceneLoader sceneLoader) : base(context) {
        CTX = context;
        _sceneLoader = sceneLoader;
    }

    public SceneManagementSystem(Context context) : base(context) {
        CTX = context;
    }

    public SceneManagementSystem(Collector collector) : base(collector) {
    }

    public static void LoadScene(SceneConfig.SceneType sceneType, string sceneName) {
        Contexts.sharedInstance.core.ReplaceSceneConfig(sceneType, sceneName);
    }

    public static void LoadScene(SceneConfig.SceneType sceneType, string sceneName, string transitionScene) {
        Contexts.sharedInstance.core.ReplaceSceneConfig(sceneType, sceneName);
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(CoreMatcher.SceneConfig, GroupEvent.Added);
    }

    protected override void Execute(List<Entity> entities) {
        // async execute loadscene from scene loader
        _sceneLoader.StartCoroutine("LoadScene");


        // any non-breakable scene change logic here, BGM change...
        ////      // custom scene change logic
        ////      PlaySceneBGM(CTX.sceneConfig.CurrentSceneType);
    }

    #region implemented abstract members of ReactiveSystem
    protected override bool Filter(Entity entity) {
        return true;
    }
    #endregion
}