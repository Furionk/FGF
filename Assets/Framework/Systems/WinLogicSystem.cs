// Solution Name: FGF
// Project: FGF
// File: WinLogicSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System.Collections.Generic;
using Entitas;

public class WinLogicSystem : ReactiveSystem {
    #region Fields
    private readonly Context ctx;
    #endregion

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