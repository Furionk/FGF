// Solution Name: FGF
// Project: FGF
// File: Bootstrapper.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using System;
using Entitas;
using UnityEngine;

using UnityEngine.Assertions;

public class Bootstrapper : MonoBehaviour {
    #region Constants
    private static IEventAggregator _eventAggregator;
    #endregion

    #region Fields

    private SceneLoader SceneLoader;
    public SceneConfig.SceneType CurrentSceneType;

    private Contexts _contexts;
    private Systems _systems;
    private Systems _subSystems;
    #endregion

    #region Properties
    public static Bootstrapper Instance { get; set; }
    public static IEventAggregator EventAggregator {
        get { return _eventAggregator ?? (_eventAggregator = new EventAggregator()); }
        set { _eventAggregator = value; }
    }
    #endregion

    public void UpdateSubsystems(SceneConfig.SceneType currentSceneType, Systems subSystems) {
        CurrentSceneType = currentSceneType;
        if (_subSystems != null) {
            _subSystems.DeactivateReactiveSystems();
            _subSystems.ClearReactiveSystems();
            _subSystems.Cleanup();
            _subSystems.TearDown();
        }
        _subSystems = subSystems;
        _subSystems.Initialize();
    }

    public void Awake() {
        Instance = this;
        _contexts = Contexts.sharedInstance;
        _contexts.SetAllContexts();
        // first run constructor
        _systems = new ImportantSystem();
        // second run init system
        _systems.Initialize();
        Contexts.sharedInstance.core.ReplaceSceneConfig(CurrentSceneType, string.Empty);
    }

    public void Update() {
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

}

public class ImportantSystem : Feature {
    public ImportantSystem() : base("MainSystem") {
        this.Add(new TimeSystem());
        this.Add(new InitSystem());
        this.Add(new SceneManagementSystem(Contexts.sharedInstance.core));
    }
}