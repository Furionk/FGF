// FGF - FGF - ContextInstaller.cs
// Created at: 2018 01 01 ¤U¤È 03:28
// Updated At: 2018 03 22 ¤U¤È 11:09
// By: Furion Mashiou

using System.Linq;
using System.Reflection;
using Entitas;
using Zenject;

public class ContextInstaller : MonoInstaller<ContextInstaller> {

    #region Methods

    public override void InstallBindings() {
        // Contexts Bindings
        Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance);
        Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game);
        Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input);

        // use reflection to get all classes with FeatureType and inject into container (ID:FeatureType)
        foreach (var systemType in Assembly.GetExecutingAssembly().GetTypes().Where(o => o.GetCustomAttributes(typeof(FeatureType), true).Any())) {
            var systemFeatureNature = systemType.GetCustomAttributes(typeof(FeatureType), true).Cast<FeatureType>().First();
            Container.Bind<ISystem>().WithId(systemFeatureNature.Nature).To(systemType).AsSingle();
        }

        // Entitas Core binding and instantiate an empty game object for it
        Container.Bind<GameController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<SceneLoadUtility>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

        // other binding that you need
        // Container.Bind<>....
    }

    #endregion

}