// Solution Name: FGF
// Project: FGF
// File: BallEntityBehaviour.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;

public class BallEntityBehaviour : EntityBehaviour {
    #region Fields
    public int LifePoint;
    public string BallName;
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
    }

    private void OnMouseDown() {
        Entity.ReplaceHP(Entity.hP.Point - 5);
    }
}