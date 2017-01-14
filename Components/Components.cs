// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: Components.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 12 - 21:12

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGenerator;

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
public class SceneConfig : IComponent {
	public enum SceneType {
		Menu,
		Game
	}

	#region Fields

	public SceneType CurrentSceneType;
	public string TargetScene;

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
public class View : IComponent {
	#region Fields

	public GameObject Value;

	#endregion
}
	