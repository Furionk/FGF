using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Zenject;

public class InputLogSystem : ReactiveSystem<InputEntity>, ICleanupSystem {

    private IGroup<InputEntity> _gOnMouseDown;

    public InputLogSystem(InputContext context) : base(context) {
        _gOnMouseDown = context.GetGroup(InputMatcher.OnMouseDown);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
        return context.CreateCollector(InputMatcher.OnMouseDown);
    }

    protected override bool Filter(InputEntity entity) {
        return true;
    }

    protected override void Execute(List<InputEntity> entities) {
        foreach (var inputEntity in entities) {
            //Debug.Log(string.Format("X{0} Y{1}", inputEntity.onMouseDown.x, inputEntity.onMouseDown.y));
        }
    }

    public void Cleanup() {
        foreach (var inputEntity in _gOnMouseDown.GetEntities()) {
            inputEntity.Destroy();
        }
    }

}
