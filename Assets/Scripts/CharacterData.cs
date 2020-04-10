using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public int MaxHP; // in a heart
    public int HP;
    public int hearts;
    public int XP;
    public int level;

    public void Start()
    {
        HP = MaxHP;
    }
}
