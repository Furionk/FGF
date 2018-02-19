// FGF - FGF - MenuSceneInstaller.cs
// Created at: 2018 01 22 �U�� 10:33
// Updated At: 2018 02 19 �U�� 05:55
// By: Furion Mashiou

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
    }

    #endregion

}