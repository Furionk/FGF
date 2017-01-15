using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGameButton : MonoBehaviour {

    public void GoToGame() {
        if (Random.Range(1, 3) == 1) {
            SceneManagementSystem.LoadScene(SceneConfig.SceneType.Game, string.Format("Game 1"));
        } else {
            SceneManagementSystem.LoadScene(SceneConfig.SceneType.RealTimeGame, string.Format("Game 2"));
        }
    }
}
