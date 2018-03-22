// FGF - FGF - MenuSceneInstaller.cs
// Created at: 2018 01 22 ¤U¤È 10:33
// Updated At: 2018 03 22 ¤U¤È 11:09
// By: Furion Mashiou

using Entitas;
using UnityEngine;
using Zenject;

public class MenuSceneInstaller : MonoInstaller<MenuSceneInstaller> {

    #region Fields

    public Transform XTTransform;

    #endregion

    #region Methods

    public override void InstallBindings() {
        Container.Bind<string>().WithId("StringData").FromInstance("Installer Data");
        Container.Bind<Transform>().WithId("XT").FromInstance(XTTransform);


        // reinject new defination to update all subsystems
        foreach (var system in Container.ResolveAll<ISystem>()) {
            Container.Inject(system);
        }
    }

    #endregion

}