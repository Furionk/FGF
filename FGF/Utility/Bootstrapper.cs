// Solution Name: FGF
// Project: FGF
// File: Bootstrapper.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;
using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    #region Constants
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
}