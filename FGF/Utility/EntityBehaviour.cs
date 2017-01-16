// Solution Name: FGF
// Project: FGF
// File: EntityBehaviour.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System;
using Entitas;
using UniRx;
using UnityEngine;

/// <summary>
///     EntityBehaviour is for game object which already in a Scene and it needs Entitas feature.
///     for real time entity creation, a 'view' is good enough to connect scene and entity
/// </summary>
public abstract class EntityBehaviour : MonoBehaviour {
    #region Fields
    private bool EntityInjected;
    #endregion

    #region Properties
    public Entity Entity { get; set; }
    /// <summary>
    ///     define which pool this entity will be in
    /// </summary>
    protected virtual Context Context { get; private set; }
    private IDisposable SceneLoadEndSubscription { get; set; }
    #endregion

    public void Initialize() {
        if (!EntityInjected) {
            if (Context == null) {
                throw new InvalidOperationException("Context must be defined.");
            }
            Entity = Context.CreateEntity();
            Setup();
        }
    }

    /// <summary>
    ///     implmenet entita initialization required logic in here.
    ///     AND also listener logic
    ///         
    /// </summary>
    public virtual void AfterInitialized() {
    }

    /// <summary>
    ///     implmenet your entity initialize logic in here if this entity is create from scene.
    /// </summary>
    /// <param name="e"></param>
    public virtual void Setup() {
    }

    /// <summary>
    ///     call it if you already created an entity from system.
    /// </summary>
    /// <param name="e"></param>
    public virtual void Inject(Context ctx, Entity e) {
        EntityInjected = true;
        Context = ctx;
        Entity = e;
        AfterInitialized();
    }

    public virtual void OnDestroy() {
        if (Entity != null) {
            Context.DestroyEntity(Entity);
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