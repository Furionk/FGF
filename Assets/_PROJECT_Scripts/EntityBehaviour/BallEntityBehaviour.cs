// Solution Name: FGF
// Project: FGF
// File: BallEntityBehaviour.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
                     
public class BallEntityBehaviour : CustomEntityBehaviour, IHandle<BecomeBiggerEvent> {
    #region Fields
    public int LifePoint;
    public string BallName;
    public Animator Anim;
    public bool IsSpecialBall;
    #endregion

    #region Properties
    protected override Context Context {
        get { return Contexts.sharedInstance.core; }
    }
    #endregion

    public override void Setup() {
        Entity.AddBall(BallName);
        Entity.AddHP(LifePoint);
        Entity.AddView(gameObject);
        Entity.IsSpecialBall(IsSpecialBall);
    }

    public override void AfterInitialized() {
        Entity.AddBecomeBiggerEventListener(this);
    }

    private void OnMouseDown() {
        Entity.ReplaceHP(Entity.hP.Point - 5);
    }

    public void Handle(BecomeBiggerEvent argument) {
        Anim.SetTrigger("BIGGER");
    }
}