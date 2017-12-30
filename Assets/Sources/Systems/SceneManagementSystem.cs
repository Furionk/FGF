using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneManagementSystem : ReactiveSystem<GameEntity>{ 

    private SceneLoadUtility _sceneLoadUtility;
    private IGroup<GameEntity> _gSceneLoad;

    public SceneManagementSystem(IContext<GameEntity> gameContext, SceneLoadUtility sceneLoadUtility) : base(gameContext) {
        _gSceneLoad = gameContext.GetGroup(GameMatcher.OnSceneLoad);
        _sceneLoadUtility = sceneLoadUtility;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.OnSceneLoad);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            _sceneLoadUtility.LoadScene(entity.onSceneLoad.nextSceneName);
            entity.Destroy();
        }
    }

}
