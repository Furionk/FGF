using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// all systems should belongs to one of the natures below
/// define nature by need to classify differnt type of system
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
