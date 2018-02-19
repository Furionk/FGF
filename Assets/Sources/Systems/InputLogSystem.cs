// FGF - FGF - InputLogSystem.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 02 19 下午 05:40
// By: Furion Mashiou

using System.Collections.Generic;
using Entitas;

namespace FGF.System {

    public class InputLogSystem : ReactiveSystem<InputEntity>, ICleanupSystem {

        #region Fields

        private IGroup<InputEntity> _gOnMouseDown;

        #endregion

        #region Constructor

        public InputLogSystem(InputContext context) : base(context) {
            _gOnMouseDown = context.GetGroup(InputMatcher.OnMouseDown);
        }

        #endregion

        #region Methods

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

        #endregion

    }

}