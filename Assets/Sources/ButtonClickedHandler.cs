// FGF - FGF - ButtonClickedHandler.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 03 22 下午 11:43
// By: Furion Mashiou

using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonClickedHandler : MonoBehaviour {

    #region Fields

    public string ButtonId;
    [Inject]
    private InputContext _inputContext;

    #endregion

    #region Constructor

    public ButtonClickedHandler(InputContext inputContext) {
        _inputContext = inputContext;
    }

    #endregion

    #region Methods

    public void Awake() {
        GetComponent<Button>().onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() {
        if (string.IsNullOrEmpty(ButtonId)) {
            _inputContext.CreateEntity().AddOnMenuButtonDown(gameObject.name);
        } else {
            _inputContext.CreateEntity().AddOnMenuButtonDown(ButtonId);
        }
    }

    #endregion

}