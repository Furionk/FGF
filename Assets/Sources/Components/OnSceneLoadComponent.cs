// FGF - FGF - OnSceneLoadComponent.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 03 22 下午 11:10
// By: Furion Mashiou

using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class OnSceneLoadComponent : IComponent {

    #region Fields

    public string nextSceneName;

    #endregion

}