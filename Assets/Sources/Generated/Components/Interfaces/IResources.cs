//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public interface IResources {

    ResourcesComponent resources { get; }
    bool hasResources { get; }

    void AddResources(string newPrefabPath);
    void ReplaceResources(string newPrefabPath);
    void RemoveResources();
}