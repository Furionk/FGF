//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public OnMenuButtonDownComponent onMenuButtonDown { get { return (OnMenuButtonDownComponent)GetComponent(InputComponentsLookup.OnMenuButtonDown); } }
    public bool hasOnMenuButtonDown { get { return HasComponent(InputComponentsLookup.OnMenuButtonDown); } }

    public void AddOnMenuButtonDown(string newButtonId) {
        var index = InputComponentsLookup.OnMenuButtonDown;
        var component = CreateComponent<OnMenuButtonDownComponent>(index);
        component.buttonId = newButtonId;
        AddComponent(index, component);
    }

    public void ReplaceOnMenuButtonDown(string newButtonId) {
        var index = InputComponentsLookup.OnMenuButtonDown;
        var component = CreateComponent<OnMenuButtonDownComponent>(index);
        component.buttonId = newButtonId;
        ReplaceComponent(index, component);
    }

    public void RemoveOnMenuButtonDown() {
        RemoveComponent(InputComponentsLookup.OnMenuButtonDown);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherOnMenuButtonDown;

    public static Entitas.IMatcher<InputEntity> OnMenuButtonDown {
        get {
            if (_matcherOnMenuButtonDown == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.OnMenuButtonDown);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherOnMenuButtonDown = matcher;
            }

            return _matcherOnMenuButtonDown;
        }
    }
}