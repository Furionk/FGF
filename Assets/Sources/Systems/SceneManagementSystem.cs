// FGF - FGF - SceneManagementSystem.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 03 22 下午 11:09
// By: Furion Mashiou

using System.Collections.Generic;
using Entitas;

namespace FGF.System {

    [FeatureType(Nature = FeatureType.Natures.GameFlow)]
    public class SceneManagementSystem : ReactiveSystem<GameEntity> {

        #region Fields

        private SceneLoadUtility   _sceneLoadUtility;
        private IGroup<GameEntity> _gSceneLoad;

        #endregion

        #region Constructor

        public SceneManagementSystem(GameContext gameContext, SceneLoadUtility sceneLoadUtility) : base(gameContext) {
            _gSceneLoad       = gameContext.GetGroup(GameMatcher.OnSceneLoad);
            _sceneLoadUtility = sceneLoadUtility;
        }

        #endregion

        #region Methods

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.OnSceneLoad);
        }

        protected override bool Filter(GameEntity entity) {
            return true;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var entity in entities) {
                _sceneLoadUtility.LoadScene(entity.onSceneLoad.nextSceneName);
                entity.Destroy();
            }
        }

        #endregion

    }

}