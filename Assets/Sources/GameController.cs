// FGF - FGF - GameController.cs
// Created at: 2018 01 01 下午 03:28
// Updated At: 2018 02 19 下午 05:45
// By: Furion Mashiou

using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour {

    #region Fields

    [Inject]
    private DiContainer _container;
    private Systems _systems;
    public static GameController Instance;

    #endregion

    #region Methods

    private void Awake() {
        Instance = this;
        Contexts ctxs = Contexts.sharedInstance;
        
        _systems = new Feature("Root Systems");
        // create entitas feature by nature
        foreach (FeatureType.Natures nature in Enum.GetValues(typeof(FeatureType.Natures))) {
            Feature newFeature = new Feature(nature.ToString());
            foreach (var system in _container.ResolveIdAll<ISystem>(nature)) {
                newFeature.Add(system);
            }
            _systems.Add(newFeature);
            Debug.Log("Feature Loaded: " + newFeature.name);
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