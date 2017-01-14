// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: EntityBehaviour.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 12 - 20:55

using System;
using UnityEngine;
using System.Collections;
using Entitas;
using UniRx;

/// <summary>
/// Monos is for game object which already in a Scene and it needs Entitas feature.
/// for real time binding, we should use a View instead.
/// </summary>
public class EntityBehaviour : MonoBehaviour {
    #region Fields
    private Action<Entity> StartSetup;
    #endregion

    #region Properties
    public Entity Entity {
        get;
        set;
    }
    public Context ctx {
        get;
        set;
    }
    #endregion

    public virtual Entity Initialize(Context whichContext) {
        ctx = whichContext;
        Entity = ctx.CreateEntity();
        return Entity;
    }

    public virtual Entity Initialize(Context whichContext, Action<Entity> awakeSetup, Action<Entity> startSetup) {
        ctx = whichContext;
        Entity = ctx.CreateEntity();
        StartSetup = startSetup;
        awakeSetup(Entity);
        return Entity;
    }

    public virtual Entity Initialize(Context whichContext, Action<Entity> startSetup) {
        ctx = whichContext;
        Entity = ctx.CreateEntity();
        StartSetup = startSetup;
        return Entity;
    }

    public virtual void Start() {
        if (Entity != null && StartSetup != null) {
            StartSetup(Entity);
        } else if (Entity == null) {
            Debug.LogError(Entity + "cannot be initialized.");
        }
    }

    public virtual void OnDestroy() {
        if (Entity != null) {
            Entity.destroy();
        } else {
            Debug.LogWarning("[" + gameObject.name + "] has no entity when destory!");
        }
    }

    public IObservable<TEvent> OnEvent<TEvent>() {
        return Bootstrapper.EventAggregator.GetEvent<TEvent>();
    }
}