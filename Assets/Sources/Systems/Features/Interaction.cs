using UnityEngine;
using System.Collections;
using Zenject;

public class Interaction : Feature {

    public Interaction(DiContainer container) : base("Interaction") {
        Add(container.Resolve<InputSystem>());
        Add(container.Resolve<InputLogSystem>());
        Add(container.Resolve<MenuButtonHandlingSystem>());
    }

}