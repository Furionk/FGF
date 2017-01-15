// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: ListenerComponents.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 11 - 23:48

using System;
using UnityEngine;
using System.Collections;
using Entitas;

[Core]
public class SceneLoadProgressListener : Listener<SceneLoadProgressMessage>, IComponent {}

[Core]
public class SceneLoadProgressMessage {
    #region Fields
    public float Progress;
    #endregion
}

[Core]
public class SceneLoadStartListener : Listener<SceneLoadStartMessage>, IComponent {}

[Core]
public class SceneLoadStartMessage {}

[Core]
public class SceneLoadEndListener : Listener<SceneLoadEndMessage>, IComponent {}

[Core]
public class SceneLoadEndMessage {}

[Core]
public class TimeListener : Listener<long>, IComponent {
	
}