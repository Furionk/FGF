using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGenerator;
using UnityEngine;

[SingleEntity]
[Core]
public class SceneConfig : IComponent {
    public enum SceneType {
        Menu,
        Game,
        RealTimeGame,
    }

    #region Fields

    public SceneType CurrentSceneType;
    public string TargetScene;

    #endregion


    public Feature SceneMapping(SceneType currentSceneType) {
        var subsystems = new Feature("Systems");
        switch (currentSceneType) {
            case SceneConfig.SceneType.Menu:
                break;
            case SceneConfig.SceneType.Game:
                subsystems.Add(new BallExplodeSystem(Contexts.sharedInstance.core));
                subsystems.Add(new WinLogicSystem(Contexts.sharedInstance.core));
                break;
            case SceneConfig.SceneType.RealTimeGame:
                subsystems.Add(new RealTimeInitializeSystem());
                subsystems.Add(new BallViewRenderingSystem(Contexts.sharedInstance.core));
                subsystems.Add(new BallExplodeSystem(Contexts.sharedInstance.core));
                subsystems.Add(new WinLogicSystem(Contexts.sharedInstance.core));
                break;
            default:
                throw new InvalidOperationException();
        }
        return subsystems;
    }

}