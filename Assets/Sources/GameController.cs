// FGF - FGF - GameController.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 02 19 下午 05:45
// By: Furion Mashiou

using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour {

    #region Fields

    [Inject]
    public List<Feature> features;
    private Systems _systems;
    public static GameObject Instance;

    #endregion

    #region Methods

    private void Awake() {
        Instance = gameObject;
    }

    // Use this for initialization
    private void Start() {
        var ctxs = Contexts.sharedInstance;
        foreach (var context in ctxs.allContexts) {
            if (context.contextInfo.componentTypes.Contains(typeof(IdComponent))) {
                context.OnEntityCreated += AddId;
            }
        }
        _systems = new Feature("Root Systems");
        foreach (var feature in features) {
            Debug.Log("[I] Feature Loaded: " + feature);
            _systems.Add(feature);
        }
        _systems.Initialize();
    }

    // Update is called once per frame
    private void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void AddId(IContext context, IEntity entity) {
        (entity as IId).AddId(entity.creationIndex);
    }

    #endregion

}