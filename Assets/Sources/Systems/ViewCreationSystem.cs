using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Zenject;

public class ViewCreationSystem : ReactiveSystem<GameEntity> {

    public ViewCreationSystem(GameContext context) : base(context) {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Resources);
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var entity in entities) {
            GameObject.Instantiate(Resources.Load(entity.resources.prefabPath));
        }
    }



}
