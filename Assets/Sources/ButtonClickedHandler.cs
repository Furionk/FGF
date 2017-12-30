using UnityEngine;
using System.Collections;
using Entitas;
using Zenject;

public class ButtonClickedHandler : MonoBehaviour {

    [Inject]
    private IContext<InputEntity> inputContext;

    public void OnButtonClicked() {
        inputContext.CreateEntity().AddOnMenuButtonDown(this.gameObject.name);
    }

}
