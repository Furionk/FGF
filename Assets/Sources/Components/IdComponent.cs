// FGF - FGF - IdComponent.cs
// Created at: 2018 02 19 下午 03:21
// Updated At: 2018 03 22 下午 11:10
// By: Furion Mashiou

using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Input]
public class IdComponent : IComponent {

    #region Fields

    [PrimaryEntityIndex]
    public int Id;

    #endregion

}