using Entitas;
using UnityEngine.UI;

public class LoadingBarEntityBehaviour : CustomEntityBehaviour,
                                         IHandle<SceneLoadStartMessage>,
                                         IHandle<SceneLoadProgressMessage> {
    #region Fields
    public Text Text;
    #endregion

    #region Properties
    protected override Context Context {
        get { return Contexts.sharedInstance.core; }
    }
    #endregion

    public override void Setup() {
    }

    public override void AfterInitialized() {
        Entity.AddSceneLoadStartListener(this);
        Entity.AddSceneLoadProgressListener(this);
    }

    public void Handle(SceneLoadProgressMessage argument) {
        Text.text = argument.Progress.ToString();
    }

    public void Handle(SceneLoadStartMessage argument) {
    }
}