using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class WinLogicSystem : ReactiveSystem {

    private Context ctx;

    public WinLogicSystem(Context context) : base(context) {
        ctx = context;
    }

    public WinLogicSystem(Collector collector) : base(collector) {
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(CoreMatcher.Ball, GroupEvent.Removed);
    }

    protected override bool Filter(Entity entity) {
        return true;
    }

    protected override void Execute(List<Entity> entities) {
        if (ctx.GetEntities(CoreMatcher.Ball).Length == 0) {
            SceneManagementSystem.LoadScene(SceneConfig.SceneType.Menu, "Menu");
        }
    }
}
