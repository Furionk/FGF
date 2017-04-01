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

        public Second second { get { return (Second)GetComponent(CoreComponentIds.Second); } }
        public bool hasSecond { get { return HasComponent(CoreComponentIds.Second); } }

        public Entity AddSecond(float newPassedSeconds) {
            var component = CreateComponent<Second>(CoreComponentIds.Second);
            component.PassedSeconds = newPassedSeconds;
            return AddComponent(CoreComponentIds.Second, component);
        }

        public Entity ReplaceSecond(float newPassedSeconds) {
            var component = CreateComponent<Second>(CoreComponentIds.Second);
            component.PassedSeconds = newPassedSeconds;
            ReplaceComponent(CoreComponentIds.Second, component);
            return this;
        }

        public Entity RemoveSecond() {
            return RemoveComponent(CoreComponentIds.Second);
        }
    }

    public partial class Context {

        public Entity secondEntity { get { return GetGroup(CoreMatcher.Second).GetSingleEntity(); } }
        public Second second { get { return secondEntity.second; } }
        public bool hasSecond { get { return secondEntity != null; } }

        public Entity SetSecond(float newPassedSeconds) {
            if(hasSecond) {
                throw new EntitasException("Could not set second!\n" + this + " already has an entity with Second!",
                    "You should check if the context already has a secondEntity before setting it or use context.ReplaceSecond().");
            }
            var entity = CreateEntity();
            entity.AddSecond(newPassedSeconds);
            return entity;
        }

        public Entity ReplaceSecond(float newPassedSeconds) {
            var entity = secondEntity;
            if(entity == null) {
                entity = SetSecond(newPassedSeconds);
            } else {
                entity.ReplaceSecond(newPassedSeconds);
            }

            return entity;
        }

        public void RemoveSecond() {
            DestroyEntity(secondEntity);
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherSecond;

        public static IMatcher Second {
            get {
                if(_matcherSecond == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.Second);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherSecond = matcher;
                }

                return _matcherSecond;
            }
        }
    }