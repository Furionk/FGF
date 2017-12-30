using UnityEngine;
using System.Collections;
using Zenject;

public class GameFlow : Feature {

    public GameFlow(DiContainer container) : base("Game Flow") {
        Add(container.Resolve<ViewCreationSystem>());
        Add(container.Resolve<SceneManagementSystem>());
        Add(container.Resolve<GameInitSystem>());
    }

}
