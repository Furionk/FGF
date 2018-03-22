//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public IdComponent id { get { return (IdComponent)GetComponent(GameComponentsLookup.Id); } }
    public bool hasId { get { return HasComponent(GameComponentsLookup.Id); } }

    public void AddId(int newId) {
        var index = GameComponentsLookup.Id;
        var component = CreateComponent<IdComponent>(index);
        component.Id = newId;
        AddComponent(index, component);
    }

    public void ReplaceId(int newId) {
        var index = GameComponentsLookup.Id;
        var component = CreateComponent<IdComponent>(index);
        component.Id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveId() {
        RemoveComponent(GameComponentsLookup.Id);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity : IId { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherId;

    public static Entitas.IMatcher<GameEntity> Id {
        get {
            if (_matcherId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Id);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherId = matcher;
            }

            return _matcherId;
        }
    }
}