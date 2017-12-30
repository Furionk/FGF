using UnityEngine;
using System.Collections;
using Entitas;
using Zenject;

public class InputSystem : IExecuteSystem {

    private IContext<InputEntity> _inputContext;

    public InputSystem(IContext<InputEntity> inputContext) {
        _inputContext = inputContext;
    }

    public void Execute() {

        if (Input.anyKey) {
            _inputContext.CreateEntity()
                .AddOnMouseDown(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

}
