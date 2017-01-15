using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGameButton : MonoBehaviour {

    public void GoToGame1() {
        SceneManagementSystem.LoadScene(SceneConfig.SceneType.Game, string.Format("Game 1"));
    }


    public void GoToGame2() {
        SceneManagementSystem.LoadScene(SceneConfig.SceneType.RealTimeGame, string.Format("Game 2"));
    }
}
