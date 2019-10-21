using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ifelse/Ghost Data", fileName = "New Ghost Data")]
public class GhostData : ScriptableObject
{
    public string discord;
    public string twitter;
    public AnimationClip animationClip;
}