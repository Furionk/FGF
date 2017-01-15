using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BallEntityBehaviour : EntityBehaviour {

    public int LifePoint;

    public string BallName;

    void Awake() {
        Initialize(Contexts.sharedInstance.core, e => {
            e.AddBall(LifePoint, BallName);
            e.AddView(this.gameObject);
        });
    }

    void OnMouseDown() {
        Entity.ReplaceBall(Entity.ball.BallLife - 5, Entity.ball.BallName);
    }
}
