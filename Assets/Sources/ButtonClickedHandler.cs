using UnityEngine;
using System.Collections;
using Entitas;
using Zenject;

public class ButtonClickedHandler : MonoBehaviour {

    [Inject]
    private InputContext inputContext;

    public void OnButtonClicked() {
        inputContext.CreateEntity().AddOnMenuButtonDown(this.gameObject.name);
    }

}
