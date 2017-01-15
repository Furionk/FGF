using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RealTimeInitializeSystem : IInitializeSystem {

    public void Initialize() {

        for (int i = 0; i < 5; i++) {
            string viewName = Random.Range(0,
                2) == 0 ? "Cylinder" : "Capsule";
            var e = Contexts.sharedInstance.core.CreateEntity();
            e.AddBall("REALTIME BALL");
            e.AddHP(Random.Range(10, 20));
            e.AddViewResources(Resources.Load(viewName) as GameObject);
        }

    }
}
