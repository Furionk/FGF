﻿// Solution Name: FGF
// Project: FGF
// File: TimeSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;
using UnityEngine;

public class TimeSystem : IInitializeSystem, IExecuteSystem {
    #region Fields
    private Context CTX;
    private float _nextTime;
    #endregion

    public void Execute() {
        //var newTick = CTX.tick.CurrentTick + 1;
        //CTX.ReplaceTick(newTick);
        if (Time.time >= _nextTime) {
            //CTX.ReplaceSecond(_nextTime);
            _nextTime += 1;
        }
    }

    public void Initialize() {
        CTX = Contexts.sharedInstance.core;
    }
}