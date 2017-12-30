using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Zenject;

public class GameController : MonoBehaviour {

    [Inject]
    public List<Feature> features;

    private Systems _systems;

	// Use this for initialization
	void Start () {
	    Contexts ctxs = Contexts.sharedInstance;
	    
	    _systems = new Feature("Root Systems");
	    foreach (var feature in features) {
            Debug.Log("[I] Feature Loaded: " + feature.ToString());
	        _systems.Add(feature);
	    }

        _systems.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
	    _systems.Execute();
        _systems.Cleanup();
	}
}
