// FGF - FGF - MenuButtonHandlingSystem.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 03 22 下午 11:09
// By: Furion Mashiou

using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace FGF.System {

    [FeatureType(Nature = FeatureType.Natures.GameFlow)]
    public class MenuButtonHandlingSystem : ReactiveSystem<InputEntity>, ICleanupSystem {

        #region Fields

        private IGroup<InputEntity>   _gOnMenuButtonDown;
        private IContext<GameEntity>  _gameContext;
        private IContext<InputEntity> _inputContext;

        #endregion

        #region Constructor

        public MenuButtonHandlingSystem(InputContext context, GameContext gameContext) : base(context) {
            _inputContext      = context;
            _gameContext       = gameContext;
            _gOnMenuButtonDown = context.GetGroup(InputMatcher.OnMenuButtonDown);
        }

        #endregion

        #region Methods

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.OnMenuButtonDown);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach (var inputEntity in entities) {
                Debug.Log(inputEntity.onMenuButtonDown.buttonId);
                if (inputEntity.onMenuButtonDown.buttonId == "NEXT") {
                    _gameContext.CreateEntity().AddOnSceneLoad("Game");
                } else if (inputEntity.onMenuButtonDown.buttonId == "BACK") {
                    _gameContext.CreateEntity().AddOnSceneLoad("Menu");
                }
            }
        }

        public void Cleanup() {
            foreach (var entity in _gOnMenuButtonDown.GetEntities()) {
                entity.Destroy();
            }
        }

        #endregion

    }

}