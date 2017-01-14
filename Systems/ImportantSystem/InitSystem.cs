// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: InitSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 05 - 0:16

using System;
using UnityEngine;
using System.Collections;
using Entitas;
using UniRx;

public class InitSystem : IInitializeSystem {

    public void Initialize() {
        Contexts.sharedInstance.core.SetCCTVOnOffStatus(false);
        Contexts.sharedInstance.core.SetGameStatus(false);
        Contexts.sharedInstance.core.SetLoad(0);
        Contexts.sharedInstance.core.SetPower(0);
        Debug.Log("Init system finished");
    }
}