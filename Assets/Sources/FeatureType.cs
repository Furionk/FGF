// FGF - FGF - FeatureType.cs
// Created at: 2018 03 22 下午 11:02
// Updated At: 2018 03 22 下午 11:43
// By: Furion Mashiou

using System;

/// <summary>
///     all systems should belongs to one of the natures below
///     define nature by need to classify differnt type of system
/// </summary>
public class FeatureType : Attribute {

    #region Fields

    public enum Natures {

        GameFlow,
        Interaction

    }

    #endregion

    #region Properties

    public Natures Nature { get; set; }

    #endregion

}