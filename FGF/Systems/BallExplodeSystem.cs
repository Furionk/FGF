// Solution Name: FGF
// Project: FGF
// File: BallExplodeSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Entitas;
using UnityEngine;

public class BallExplodeSystem : ReactiveSystem {
    #region Fields
    private Context ctx;
    #endregion

    public BallExplodeSystem(Context context) : base(context) {
        ctx = context;
    }

    public BallExplodeSystem(Collector collector) : base(collector) {
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(Matcher.AllOf(CoreMatcher.Ball, CoreMatcher.HP), GroupEvent.Added);
    }

    protected override bool Filter(Entity entity) {
        return true;
    }

    protected override void Execute(List<Entity> entities) {
        // for each entity which have Ball component and being modified
        foreach (var entity in entities) {
            if (entity.hP.Point <= 0) {
                Object.Destroy(entity.view.Value.gameObject);
                ctx.DestroyEntity(entity);
            }
        }
    }
}