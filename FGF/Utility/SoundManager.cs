// Solution Name: FGF
// Project: FGF
// File: SoundManager.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using UnityEngine;

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

    private void Update() {
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