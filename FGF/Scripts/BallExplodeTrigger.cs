using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExplodeTrigger : MonoBehaviour {

    // for demo usage, this logic can be placed in 
    void OnMouseDown() {
        var entity = GetComponent<EntityBehaviour>().Entity;
        entity.ReplaceBall(entity.ball.BallLife - 5, entity.ball.BallName);
    }
}
