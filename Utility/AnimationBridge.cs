using UnityEngine;
using System.Collections;
using Entitas;

public class AnimationBridge : MonoBehaviour {
    public void BridgeEvent(string eventName) {
        if (eventName == "KillAnimationFinished") {
            
        } else if (eventName == "CCTVBoxLoaded") {
            Contexts.sharedInstance.core.ReplaceCCTVOnOffStatus(true);
        }
    }
}
