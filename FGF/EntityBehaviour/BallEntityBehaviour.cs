using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BallEntityBehaviour : EntityBehaviour {

    public int LifePoint;

    public string BallName;

    public override Context Context {
        get { return Contexts.sharedInstance.core; }
    }

    public override void Setup() {
        Entity.AddBall(BallName);
        Entity.AddHP(LifePoint);
        Entity.AddView(this.gameObject);
    }


    void OnMouseDown() {
        Entity.ReplaceHP(Entity.hP.Point - 5);
    }
}
