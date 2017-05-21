﻿// Solution Name: FGF
// Project: FGF
// File: BallViewRenderingSystem.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BallViewRenderingSystem : ReactiveSystem {
    #region Fields
    private readonly Context ctx;
    #endregion

    public BallViewRenderingSystem(Context context) : base(context) {
        ctx = context;
    }

    public BallViewRenderingSystem(Collector collector) : base(collector) {
    }

    protected override Collector GetTrigger(Context context) {
        return context.CreateCollector(Matcher.AllOf(CoreMatcher.Ball, CoreMatcher.ViewResources), GroupEvent.Added);
    }

    protected override bool Filter(Entity entity) {
        return true;
    }

    protected override void Execute(List<Entity> entities) {
        foreach (var entity in entities) {
            var go = entity.InstantiateViewAndInject(Contexts.sharedInstance.core);
            go.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(0, 5));
        }
    }
}