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

        public View view { get { return (View)GetComponent(CoreComponentIds.View); } }
        public bool hasView { get { return HasComponent(CoreComponentIds.View); } }

        public Entity AddView(UnityEngine.GameObject newValue) {
            var component = CreateComponent<View>(CoreComponentIds.View);
            component.Value = newValue;
            return AddComponent(CoreComponentIds.View, component);
        }

        public Entity ReplaceView(UnityEngine.GameObject newValue) {
            var component = CreateComponent<View>(CoreComponentIds.View);
            component.Value = newValue;
            ReplaceComponent(CoreComponentIds.View, component);
            return this;
        }

        public Entity RemoveView() {
            return RemoveComponent(CoreComponentIds.View);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherView;

        public static IMatcher View {
            get {
                if(_matcherView == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.View);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherView = matcher;
                }

                return _matcherView;
            }
        }
    }
