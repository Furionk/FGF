using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

public static class EntityExtensions {

    public static GameObject InstantiateViewAndInject<T>(this Entity entity, Context ctx) where T : EntityBehaviour {
        if (entity.hasView) {
            throw new InvalidOperationException("Entity already has a view");
        }
        if (!entity.hasViewResources) {
            throw new InvalidOperationException("Entity has no view resources");

        }
        var go = Object.Instantiate(entity.viewResources.GameObject);
        go.GetComponent<T>().Inject(ctx, entity);
        return go;
    }

}
