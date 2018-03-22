// FGF - FGF - GameInitSystem.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 02 19 下午 05:40
// By: Furion Mashiou

using Entitas;
using Zenject;

namespace FGF.System {

    [FeatureType(Nature = FeatureType.Natures.GameFlow)]
    public class GameInitSystem : IInitializeSystem {

        #region Fields

        [Inject]
        public GameContext game;

        #endregion

        #region Methods

        public void Initialize() {
        }

        #endregion

    }

}