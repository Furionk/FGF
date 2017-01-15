// Solution Name: FGF
// Project: FGF
// File: TimeSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;
using UnityEngine;

public class TimeSystem : IInitializeSystem, IExecuteSystem {
    #region Fields
    private Context ctx;
    private float _nextTime;
    #endregion

    public void Execute() {
        var newTick = ctx.tick.CurrentTick + 1;
        ctx.ReplaceTick(newTick);
        if (Time.time >= _nextTime) {
            ctx.ReplaceSecond(_nextTime);
            _nextTime += 1;
        }
    }

    public void Initialize() {
        ctx = Contexts.sharedInstance.core;
        ctx.SetTick(0);
    }
}