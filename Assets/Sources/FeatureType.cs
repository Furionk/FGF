using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// all system should belongs to one of the nature below
/// developer may add custom nature to classify differnt types of system
/// feature nature would be shown as Feature in Entitas
/// </summary>
public class FeatureType : Attribute {

    public enum Natures {

        GameFlow,
        Interaction

    }

    public Natures Nature {
        get;
        set;
    }

}
