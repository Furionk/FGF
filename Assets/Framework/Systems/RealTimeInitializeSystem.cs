// Solution Name: FGF
// Project: FGF
// File: RealTimeInitializeSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;
using UnityEngine;

public class RealTimeInitializeSystem : IInitializeSystem {
    public void Initialize() {
        for (var i = 0; i < 5; i++) {
            var viewName = Random.Range(0,
                2) == 0 ? "Cylinder" : "Capsule";
            var e = Contexts.sharedInstance.core.CreateEntity();
            e.AddBall("REALTIME BALL");
            e.AddHP(Random.Range(10, 20));
            e.AddViewResources(Resources.Load(viewName) as GameObject);
        }
    }
}