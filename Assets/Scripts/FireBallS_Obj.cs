﻿using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "New Fire Ball", menuName = "Fire Ball")]
public class FireBallS_Obj : ScriptableObject
{
    public AnimatorController m_animatorController;
    public Sprite m_sprite;
    public string m_name;
    public float m_lifeTime;
    public int m_DP;
}
