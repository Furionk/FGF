using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Entitas;
using UnityEngine;

public class BallExplodeSystem : ReactiveSystem {

    private Context ctx;

    public BallExplodeSystem(Context context) : base(context) {
        ctx = context;
    }

    public BallExplodeSystem(Collector collector) : base(collector) {
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(CoreMatcher.Ball, GroupEvent.Added);
    }

    protected override bool Filter(Entity entity) {
        return true;
    }

    protected override void Execute(List<Entity> entities) {
        // for each entity which have Ball component and being modified
        foreach (var entity in entities) {
            if (entity.ball.BallLife <= 0) {
                GameObject.Destroy(entity.view.Value.gameObject);
                entity.Release(ctx);
            }
        }
    }
}
