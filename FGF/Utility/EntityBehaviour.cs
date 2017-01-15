// Solution Name: FGF
// Project: FGF
// File: EntityBehaviour.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 15:53

using System;
using UnityEngine;
using System.Collections;
using Entitas;
using UniRx;

/// <summary>
/// EntityBehaviour is for game object which already in a Scene and it needs Entitas feature.
/// for real time entity creation, a 'view' is good enough to connect scene and entity
/// </summary>
public class EntityBehaviour : MonoBehaviour {
    #region Fields
    public bool EntityInjected;
    private Action<Entity> StartSetup;
    #endregion

    #region Properties
    public Entity Entity { get; set; }
    public virtual Context Context { get; private set; }
    private IDisposable SceneLoadEndSubscription { get; set; }
    #endregion

    public virtual void Awake() {
        SceneLoadEndSubscription = OnEvent<SceneLoadEndMessage>()
            .Subscribe(msg => {
                if (!EntityInjected) {
                    Entity = Context.CreateEntity();
                    Setup();
                }
            });
    }


    /// <summary>
    /// implmenete your initialize logic in here if it is 
    /// </summary>
    /// <param name="e"></param>
    public virtual void Setup() {
        throw new NotImplementedException();
    }

    /// <summary>
    /// call it if you already created from system
    /// </summary>
    /// <param name="e"></param>
    public virtual void Inject(Context ctx, Entity e) {
        Context = ctx;
        EntityInjected = true;
        Entity = e;
    }


    public virtual void OnDestroy() {
        if (Entity != null) {
            Entity.destroy();
        } else {
            Debug.LogWarning("[" + gameObject.name + "] has no entity when destory!");
        }
        if (SceneLoadEndSubscription != null) {
            SceneLoadEndSubscription.Dispose();
        }
    }

    public IObservable<TEvent> OnEvent<TEvent>() {
        return Bootstrapper.EventAggregator.GetEvent<TEvent>();
    }
}