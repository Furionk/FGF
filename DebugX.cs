using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DebugX : EntityBehaviour
    , IHandle<SceneLoadEndMessage>
    , IHandle<SceneLoadProgressMessage>
    , IHandle<SceneLoadStartMessage> {

    protected override Context Context {
        get { return Contexts.sharedInstance.core; }
    }
    public override void Setup() {
        Entity.AddSceneLoadStartListener(this);
        Entity.AddSceneLoadProgressListener(this);
        Entity.AddSceneLoadEndListener(this);
    }

    public void Handle(SceneLoadEndMessage argument) {
        Debug.Log("E");
    }

    public void Handle(SceneLoadProgressMessage argument) {
        Debug.Log("P");
    }

    public void Handle(SceneLoadStartMessage argument) {
        Debug.Log("S");
    }
}
