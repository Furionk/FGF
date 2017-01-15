// Solution Name: FGF
// Project: FGF
// File: Components.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;
using Entitas.CodeGenerator;
using UnityEngine;

////// Naming convention

////// EntityBehaviour
//////    - A monobehaviour with entity

////// Listener_{...}
//////    - A component means this mono will receive the specified event.
[SingleEntity]
[Core]
public class Subsystems : IComponent {
    #region Fields
    public Systems Systems;
    #endregion
}

[SingleEntity]
[Core]
public class Tick : IComponent {
    #region Fields
    public long CurrentTick;
    #endregion
}

[SingleEntity]
[Core]
public class Second : IComponent {
    #region Fields
    public float PassedSeconds;
    #endregion
}

[Core]
public class ViewResources : IComponent {
    #region Fields
    public GameObject Value;
    #endregion
}

[Core]
public class View : IComponent {
    #region Fields
    public GameObject Value;
    #endregion
}