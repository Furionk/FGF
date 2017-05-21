// Solution Name: FGF
// Project: FGF
// File: RunGameButton.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using UnityEngine;

public class RunGameButton : MonoBehaviour {
    public void GoToGame1() {
        SceneManagementSystem.LoadScene(SceneConfig.SceneType.Game, "Game 1");
    }

    public void GoToGame2() {
        SceneManagementSystem.LoadScene(SceneConfig.SceneType.RealTimeGame, "Game 2");
    }
}