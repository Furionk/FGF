using UnityEngine;
using System.Collections;
using Entitas;
using UnityEngine.UI;
using Zenject;

public class ButtonClickedHandler : MonoBehaviour {

    [Inject]
    private InputContext _inputContext;

    public ButtonClickedHandler(InputContext inputContext) {
        _inputContext = inputContext;
    }

    public string ButtonId;

    public void Awake() {
        this.GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() {
        if (string.IsNullOrEmpty(ButtonId)) {
            _inputContext.CreateEntity().AddOnMenuButtonDown(this.gameObject.name);
        } else {
            _inputContext.CreateEntity().AddOnMenuButtonDown(ButtonId);
        }
    }

}
