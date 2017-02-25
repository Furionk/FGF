using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

public static class EntityExtensions {

    public static GameObject InstantiateViewAndInject(this Entity entity, Context ctx) {
        if (entity.hasView) {
            throw new InvalidOperationException("Entity already has a view");
        }
        if (!entity.hasViewResources) {
            throw new InvalidOperationException("Entity has no view resources");
        }
        GameObject newGameObject = Object.Instantiate(entity.viewResources.GameObject);
        foreach(EntityBehaviour entityBehaviour in newGameObject.GetComponents<EntityBehaviour>()) {
            entityBehaviour.Inject(ctx, entity);
        }
        entity.AddView(newGameObject);
        return newGameObject;
    }

}
