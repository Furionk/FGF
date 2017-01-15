// Solution Name: FGF
// Project: FGF
// File: RunGameButton.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

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