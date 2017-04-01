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

        static readonly SpecialBall specialBallComponent = new SpecialBall();

        public bool isSpecialBall {
            get { return HasComponent(CoreComponentIds.SpecialBall); }
            set {
                if(value != isSpecialBall) {
                    if(value) {
                        AddComponent(CoreComponentIds.SpecialBall, specialBallComponent);
                    } else {
                        RemoveComponent(CoreComponentIds.SpecialBall);
                    }
                }
            }
        }

        public Entity IsSpecialBall(bool value) {
            isSpecialBall = value;
            return this;
        }
    }
}

    public partial class CoreMatcher {

        static IMatcher _matcherSpecialBall;

        public static IMatcher SpecialBall {
            get {
                if(_matcherSpecialBall == null) {
                    var matcher = (Matcher)Matcher.AllOf(CoreComponentIds.SpecialBall);
                    matcher.componentNames = CoreComponentIds.componentNames;
                    _matcherSpecialBall = matcher;
                }

                return _matcherSpecialBall;
            }
        }
    }