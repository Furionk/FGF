// FGF - FGF - InputSystem.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 03 22 下午 11:09
// By: Furion Mashiou

using Entitas;
using UnityEngine;
using Zenject;

namespace FGF.System {

    [FeatureType(Nature = FeatureType.Natures.Interaction)]
    public class InputSystem : IExecuteSystem {

        #region Fields

        private IContext<InputEntity> _inputContext;
        private Transform             TF;

        #endregion

        #region Constructor

        public InputSystem(InputContext inputContext) {
            _inputContext = inputContext;
        }

        #endregion

        #region Methods

        [Inject]
        public void Init([InjectOptional(Id = "XT")] Transform mTF) {
            TF = mTF;
        }

        public void Execute() {
            if (Input.anyKey) {
                _inputContext.CreateEntity().AddOnMouseDown(Input.mousePosition.x, Input.mousePosition.y);

                //if (TF == null) {
                //    Zenject.ProjectContext.Instance.Container.InjectGameObject(GameController.Instance);
                //}

                //TF.localScale = TF.localScale * 1.1f;
                //Container.ResolveId<Transform>("XT").localScale = Container.Resolve<Transform>().localScale * 1.1f;
            }
        }

        #endregion

    }

}