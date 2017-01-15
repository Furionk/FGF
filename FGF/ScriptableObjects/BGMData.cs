// Solution Name: FGF
// Project: FGF
// File: BGMData.cs
// 
// By: Furion
// Last Pinned Datetime: 2017 / 01 / 15 - 16:46

using UnityEngine;

[CreateAssetMenu(menuName = "BGM Data")]
public class BGMData : ScriptableObject {
    #region Fields
    public SceneConfig.SceneType SceneType;
    public AudioClip[] Clips;
    #endregion
}