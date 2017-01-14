// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: Listener.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 05 - 0:16

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener<T> {
    #region Fields
    public IHandle<T> Target;
    #endregion

    public void Notify(T arg) {
        if (Target != null) {
            Target.Handle(arg);
        }
    }
}