using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BecomeBiggerButton : MonoBehaviour {

    public void Bigger() {
        foreach (var entity in Contexts.sharedInstance.core.GetEntities(CoreMatcher.BecomeBiggerEventListener)) {
            entity.becomeBiggerEventListener.Notify(new BecomeBiggerEvent());
        }
    }
}
