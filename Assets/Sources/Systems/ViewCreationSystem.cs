// FGF - FGF - ViewCreationSystem.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 03 22 下午 11:09
// By: Furion Mashiou

using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace FGF.System {

    [FeatureType(Nature = FeatureType.Natures.GameFlow)]
    public class ViewCreationSystem : ReactiveSystem<GameEntity> {

        #region Constructor

        public ViewCreationSystem(GameContext context) : base(context) {
        }

        #endregion

        #region Methods

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
            return context.CreateCollector(GameMatcher.Resources);
        }

        protected override bool Filter(GameEntity entity) {
            return true;
        }

        protected override void Execute(List<GameEntity> entities) {
            foreach (var entity in entities) {
                GameObject.Instantiate(Resources.Load(entity.resources.prefabPath));
            }
        }

        #endregion

    }

}