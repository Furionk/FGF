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
public class GameStatus : IComponent {
    #region Fields
    public bool GameOver;
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

[SingleEntity]
[Core]
public class CCTVOnOffStatus : IComponent {
    public bool IsOpenning;
}

[SingleEntity]
[Core]
public class ObservingCCTVInfo : IComponent {
    public Entity CCTV;
}

[SingleEntity]
[Core]
public class Power : IComponent {
    #region Fields
    public int Value;
    #endregion
}

[SingleEntity]
[Core]
public class Load : IComponent {
    #region Fields
    public int PowerLoaded;
    #endregion
}

[Core]
public class View : IComponent {
    #region Fields
    public GameObject Value;
    #endregion
}

#region Room Related
[Core]
public class CCTV : IComponent {
    #region Fields
    public int Number;
    public string Name;
    #endregion
}

[Core]
public class NodeRelationship : IComponent {
    public IEnumerable<Entity> BackwardNodes;
    public IEnumerable<Entity> ForwardNodes;
    public IEnumerable<Entity> AllNodes;
}

[Core]
public class Node : IComponent {
    #region Fields
    public Vector3 Position;
    public string ID;
    public float ExtraCoolDown;
    public bool IsKillNode;
    public bool IsPlayerNode;
    public bool IsRightKillNode;
    public bool IsLeftKillNode;
    public AnimatronicAppearanceInfo[] AppearanceInfos;
    #endregion
}

[Serializable]
[Core]
public class AnimatronicAppearanceInfo {
    #region Fields
    public AnimatronicType Type;
    public Vector3 PositionOffset;
    public Vector3 RotationOffset;
    public int AnimationID;
    public float ExtraCoolDown;
    public int ExtraMovementStep;
    #endregion

    //public NodeEntityBehaviour[] CheatNextNodes;
}
#endregion

#region Animatronic & Node
public enum AnimatronicType {
    CrazyUnityChan
}

[Core]
public class AnimatronicStartNode : IComponent {
}

[Core]
public class AnimatronicComponent : IComponent {
    #region Fields
    public string Name;
    public int Complexity;
    public float BasicCooldown;
    public AnimatronicType Type;
    #endregion
}

[Core]
public class AnimatronicPosition : IComponent {
    #region Fields
    public Entity NodeEntity;
    #endregion
}

[Core]
public class AnimatronicMovement : IComponent {
    #region Fields
    public float Cooldown;
    #endregion
}

[Core]
public class AggressiveAnimatronic : IComponent {
}

[Core]
public class FastAnimatronic : IComponent {
}
#endregion

#region Door
[Core]
public class Door : IComponent {
    #region Fields
    public int Id;
    public Animator Anim;
    #endregion
}

[Core]
public class DoorStatus : IComponent {
    #region Fields
    public bool Openning;
    #endregion

    #region Properties
    public bool IsClosed {
        get { return Openning == false; }
    }
    #endregion
}
#endregion