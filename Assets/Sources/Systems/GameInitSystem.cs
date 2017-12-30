using UnityEngine;
using System.Collections;
using Entitas;
using Zenject;

public class GameInitSystem : IInitializeSystem { 

    [Inject]
    public IContext<GameEntity> game;


    public void Initialize() {

    }

}
