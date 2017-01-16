using Entitas;
using UnityEngine.UI;

public class LoadingBarEntityBehaviour : EntityBehaviour, 
    IHandle<SceneLoadStartMessage> ,
    IHandle<SceneLoadProgressMessage> {

    public Text Text;

    #region Properties
    protected override Context Context {
        get { return Contexts.sharedInstance.core; }
    }
    #endregion

    public override void Setup() {
        Entity.AddSceneLoadStartListener(this);
        Entity.AddSceneLoadProgressListener(this);
    }

    public void Handle(SceneLoadStartMessage argument) {
    }

    public void Handle(SceneLoadProgressMessage argument) {
        Text.text = argument.Progress.ToString();
    }
}