using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ifelse/Music Data", fileName = "New Music Data")]
public class MusicData : ScriptableObject
{
    public AudioClip clip;

    public string artist,
                  album,
                  song;

    [Space]
    public float beatsPerMinute;
}