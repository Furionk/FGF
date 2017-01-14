using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "BGM Data")]
public class BGMData : ScriptableObject {

    public SceneConfig.SceneType SceneType;
    public AudioClip[] Clips;
}
