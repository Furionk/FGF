// Solution Name: Area.Entitia
// Project: Area.Entitia
// File: SoundManager.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 14 - 16:36

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour {
    #region Constants
    public static SoundManager Instance;
    #endregion

    #region Fields
    public AudioSource BGMAudioSource;
    private BGMData currentBGMData;
    #endregion

    public void PlayBGM(BGMData newBGMData) {
        currentBGMData = newBGMData;
    }

    void Update() {
        if (!BGMAudioSource.isPlaying && currentBGMData != null) {
            if (currentBGMData.Clips.Length > 0) {
                BGMAudioSource.clip = currentBGMData.Clips[Random.Range(0, currentBGMData.Clips.Length - 1)];
                BGMAudioSource.Play();
            }
        }
    }

    private void Awake() {
        Instance = this;
    }
}