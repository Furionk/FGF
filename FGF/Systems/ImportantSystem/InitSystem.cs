// Solution Name: FGF
// Project: FGF
// File: InitSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System;
using UnityEngine;
using System.Collections;
using Entitas;
using UniRx;

public class InitSystem : IInitializeSystem {
    public void Initialize() {
        Debug.Log("Init system finished");
    }
}