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
    public AudioSource FxAudioSource;
    public Animator Anim;
    private BGMData currentBGMData;
    private bool buffering = false;
    #endregion

    public void PlayBGM(BGMData newBGMData) {
        buffering = true;
        currentBGMData = newBGMData;
        Anim.SetTrigger("BGM_SWITCHING");
    }

    public void Anim_ActualPlay() {
        buffering = false;
    }

    void Update() {
        if (buffering) return;
        if (!BGMAudioSource.isPlaying) {
            BGMAudioSource.clip = currentBGMData.Clips[Random.Range(0, currentBGMData.Clips.Length - 1)];
            BGMAudioSource.Play();
        }
    }

    public void PlayFX(AudioClip clip) {
        FxAudioSource.PlayOneShot(clip);
    }

    private void Awake() {
        Instance = this;
    }
}