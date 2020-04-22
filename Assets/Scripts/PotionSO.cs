using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Potion")]
public class PotionSO : ScriptableObject
{
    public enum Type
    {
        Heal,
        Power,
        Speed
    }

    public Type type;
    public Sprite m_sprite;
    public int m_gain;
    public float m_actionTime;
}
