// Solution Name: FGF
// Project: FGF
// File: ListenerComponents.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using Entitas;

[Core]
public class SceneLoadProgressListener : Listener<SceneLoadProgressMessage>, IComponent {
}

[Core]
public class SceneLoadProgressMessage {
    public enum SceneLoadProgressType {
        UnityScenePart,
        EntitasPart
    }

    #region Fields
    public SceneLoadProgressType Type;
    public float Progress;
    #endregion
}

[Core]
public class SceneLoadStartListener : Listener<SceneLoadStartMessage>, IComponent {
}

[Core]
public class SceneLoadStartMessage {
}

[Core]
public class SceneLoadEndListener : Listener<SceneLoadEndMessage>, IComponent {
}

[Core]
public class SceneLoadEndMessage {
}

[Core]
public class TimeListener : Listener<long>, IComponent {
}