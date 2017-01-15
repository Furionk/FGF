using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BallViewRenderingSystem : ReactiveSystem {
    private Context ctx;

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
            if (!entity.hasView) {
                var go = GameObject.Instantiate(entity.viewResources.Value);
                go.GetComponent<BallEntityBehaviour>().Inject(entity);
                go.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
                entity.AddView(go);
            }
        }
    }
}
