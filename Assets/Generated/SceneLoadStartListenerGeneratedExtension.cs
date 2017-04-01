//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Entitas;

namespace Entitas {

    public partial class Entity {

        public SceneLoadStartListener sceneLoadStartListener { get { return (SceneLoadStartListener)GetComponent(CoreComponentIds.SceneLoadStartListener); } }
        public bool hasSceneLoadStartListener { get { return HasComponent(CoreComponentIds.SceneLoadStartListener); } }

        public Entity AddSceneLoadStartListener(IHandle<SceneLoadStartMessage> newTarget) {
            var component = CreateComponent<SceneLoadStartListener>(CoreComponentIds.SceneLoadStartListener);
            component.Target = newTarget;
            return AddComponent(CoreComponentIds.SceneLoadStartListener, component);
        }

        public Entity ReplaceSceneLoadStartListener(IHandle<SceneLoadStartMessage> newTarget) {
            var component = CreateComponent<SceneLoadStartListener>(CoreComponentIds.SceneLoadStartListener);
            component.Target = newTarget;
            ReplaceComponent(CoreComponentIds.SceneLoadStartListener, component);
            return this;
        }

        public Entity RemoveSceneLoadStartListener() {
            return RemoveComponent(CoreComponentIds.SceneLoadStartListener);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherSceneLoadStartListener;

        public static IMatcher SceneLoadStartListener {
            get {
                if(_matcherSceneLoadStartListener == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.SceneLoadStartListener);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherSceneLoadStartListener = matcher;
                }

                return _matcherSceneLoadStartListener;
            }
        }
    }