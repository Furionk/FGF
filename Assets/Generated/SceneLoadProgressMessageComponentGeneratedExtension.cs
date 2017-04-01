//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

public class SceneLoadProgressMessageComponent : IComponent {

    public SceneLoadProgressMessage value;
}

namespace Entitas {

    public partial class Entity {

        public SceneLoadProgressMessageComponent sceneLoadProgressMessage { get { return (SceneLoadProgressMessageComponent)GetComponent(CoreComponentIds.SceneLoadProgressMessage); } }
        public bool hasSceneLoadProgressMessage { get { return HasComponent(CoreComponentIds.SceneLoadProgressMessage); } }

        public Entity AddSceneLoadProgressMessage(SceneLoadProgressMessage newValue) {
            var component = CreateComponent<SceneLoadProgressMessageComponent>(CoreComponentIds.SceneLoadProgressMessage);
            component.value = newValue;
            return AddComponent(CoreComponentIds.SceneLoadProgressMessage, component);
        }

        public Entity ReplaceSceneLoadProgressMessage(SceneLoadProgressMessage newValue) {
            var component = CreateComponent<SceneLoadProgressMessageComponent>(CoreComponentIds.SceneLoadProgressMessage);
            component.value = newValue;
            ReplaceComponent(CoreComponentIds.SceneLoadProgressMessage, component);
            return this;
        }

        public Entity RemoveSceneLoadProgressMessage() {
            return RemoveComponent(CoreComponentIds.SceneLoadProgressMessage);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherSceneLoadProgressMessage;

        public static IMatcher SceneLoadProgressMessage {
            get {
                if(_matcherSceneLoadProgressMessage == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.SceneLoadProgressMessage);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherSceneLoadProgressMessage = matcher;
                }

                return _matcherSceneLoadProgressMessage;
            }
        }
    }