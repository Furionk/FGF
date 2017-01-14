// Solution Name: Area.Entitia
// Project: Area.Entitia.CSharp
// File: Kernel.cs
// 
// By: Furion
// Last Pinned Datetime: 2016 / 11 / 04 - 20:42

using UnityEngine;
using System.Collections;
using System.Linq;
using Entitas;

public class Bootstrapper : MonoBehaviour {
    #region Constants
    private static Bootstrapper _instace;
    private static IEventAggregator _eventAggregator;
    #endregion

    #region Fields

    // debug usage
    public SceneConfig.SceneType CurrentSceneType;
    private Contexts Ctxs;
    private Systems _systems;
    private Systems _subSystems;
    #endregion

    #region Properties
    public static Bootstrapper Instance {
        get { return _instace; }
        set { _instace = value; }
    }
    public static IEventAggregator EventAggregator {
        get { return _eventAggregator ?? (_eventAggregator = new EventAggregator()); }
        set { _eventAggregator = value; }
    }
    #endregion

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        } else {
            Instance = this;
            Ctxs = Contexts.sharedInstance;
            Ctxs.SetAllContexts();
            // first run constructor
            _systems = CreateImportantSystems(Ctxs);
            // second run init system
            _systems.Initialize();
            Contexts.sharedInstance.core.ReplaceSceneConfig(CurrentSceneType, string.Empty);
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update() {
        _systems.Execute();
        if (_subSystems != null) {
            _subSystems.Execute();
            _subSystems.Cleanup();
        }
        _systems.Cleanup();
    }

    private void OnDestroy() {
        if (_systems != null) {
            _systems.TearDown();
        }
        if (_subSystems != null) {
            _subSystems.TearDown();
        }
    }

    private Systems CreateImportantSystems(Contexts contexts) {
        return new Feature("Systems")
        .Add(new TimeSystem())
        .Add(new InitSystem())
        .Add(new SceneManagementSystem(contexts.core, GetComponent<SceneLoader>()))
        ;
    }

    public void UpdateSubsystems(Systems subSystems) {
        if (_subSystems != null) {
            _subSystems.DeactivateReactiveSystems();
            _subSystems.ClearReactiveSystems();
            _subSystems.Cleanup();
            _subSystems.TearDown();
        }
        _subSystems = subSystems;
        _subSystems.Initialize();
    }
}