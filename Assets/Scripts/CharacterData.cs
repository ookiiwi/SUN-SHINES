using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public bool useHearts = false;
    public int MaxHP;
    public int HP;
    public int prevHP;
    public int hearts;
    public int emptyHearts;
    public int XP;
    public int level;

    public FireBallS_Obj fireBallUsed;

    public void Start()
    {
        HP = MaxHP;
        prevHP = HP;
    }
}
