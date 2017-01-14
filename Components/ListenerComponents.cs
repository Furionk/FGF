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
public class TimeListener : Listener<long>, IComponent {}

[Core]
public class Listener_NodeChanged : Listener<Node>, IComponent {}

[Core]
public class Listener_OpenningCCTV : Listener<Boolean>, IComponent {}

[Core]
public class Listener_ObservingCCTVhanged : Listener<CCTVChangedMessage>, IComponent {}

[Core]
public class CCTVChangedMessage {
    #region Fields
    public int NewCCTVID;
    public int LastCCTVID;
    public string Location;
    #endregion
}

[Core]
public class Listener_DoorStatusChanged : Listener<bool>, IComponent {}

[Core]
public class Listener_AnimatronicMovement : Listener<AnimatronicMovedEvent>, IComponent {}

[Core]
public class AnimatronicMovedEvent {
    #region Fields
    public Node NewNode;
    #endregion
}

[Core]
public class Listener_PowerChanged : Listener<PowerChangedEvent>, IComponent {}

[Core]
public class PowerChangedEvent {
    #region Fields
    public int Value;
    #endregion
}

[Core]
public class Listener_LoadChanged : Listener<LoadChangedEvent>, IComponent {}

[Core]
public class LoadChangedEvent {
    #region Fields
    public Load NewLoad;
    #endregion
}

[Core]
public class Listener_GameStatusChanged : Listener<GameStatusChangedEvent>, IComponent {}

[Core]
public class GameStatusChangedEvent {
    #region Fields
    public GameStatus NewGameStatus;
    #endregion
}