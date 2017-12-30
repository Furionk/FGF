using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSceneInstaller", menuName = "Installers/GameSceneInstaller")]
public class GameSceneInstaller : ScriptableObjectInstaller<GameSceneInstaller> {

    public int NumberOfCube;

    public override void InstallBindings() {

        for (int i = 0; i < NumberOfCube; i++) {
            Contexts.sharedInstance.game.CreateEntity().AddResources("GameCube");
        }


    }
}