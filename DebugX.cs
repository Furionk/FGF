using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DebugX : MonoBehaviour {
    private List<Entity> @group = new List<Entity>();

    public void Start() {

        //Invoke("Create", 0);

    }

    //void Create() {
    //    @group.Clear();
    //    for (int i = 0; i < 5000; i++) {
    //        group.Add(Contexts.sharedInstance.core.CreateEntity());
    //    }
    //    Invoke("Remove", 1);
    //}

    //void Remove() {
    //    foreach (var entity in group) {
    //        Contexts.sharedInstance.core.DestroyEntity(entity);
    //    }
    //    Invoke("Create", 1);
    //}

}
