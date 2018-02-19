// FGF - FGF - ContextInstaller.cs
// Created at: 2018 01 01 ¤U¤È 03:28
// Updated At: 2018 02 19 ¤U¤È 05:55
// By: Furion Mashiou

using Entitas;
using FGF.System;
using Zenject;

public class ContextInstaller : MonoInstaller<ContextInstaller> {

    #region Methods

    public override void InstallBindings() {
        // Contexts
        Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game);
        Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input);

        // Systems
        Container.Bind<ISystem>().WithId(FeatureType.All).To(o => o.AllNonAbstractClasses().InNamespace("FGF.System")).AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.Interaction).To<InputSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.Interaction).To<InputLogSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.Interaction).To<MenuButtonHandlingSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<GameInitSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<SceneManagementSystem>().AsSingle();
        Container.Bind<ISystem>().WithId(FeatureType.GameFlow).To<ViewCreationSystem>().AsSingle();

        // Features
        Container.Bind<Feature>().To<GameFlow>().AsSingle();
        Container.Bind<Feature>().To<Interaction>().AsSingle();

        // Entitas Core
        Container.Bind<GameController>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.Bind<SceneLoadUtility>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }

    #endregion

}

public enum FeatureType {

    All,
    GameFlow,
    Interaction

}

public class GameFlow : Feature {

    #region Constructor

    public GameFlow(DiContainer container) : base(FeatureType.GameFlow.ToString()) {
        foreach (var system in container.ResolveIdAll<ISystem>(FeatureType.GameFlow)) {
            Add(system);
        }
    }

    #endregion

}

public class Interaction : Feature {

    #region Constructor

    public Interaction(DiContainer container) : base(FeatureType.Interaction.ToString()) {
        foreach (var system in container.ResolveIdAll<ISystem>(FeatureType.Interaction)) {
            Add(system);
        }
    }

    #endregion

}