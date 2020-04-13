using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public bool useHearts = false;
    public int MaxHP;
    public int HP;
    public int hearts;
    public int emptyHearts;
    public int XP;
    public int level;

    public void Start()
    {
        HP = MaxHP;
    }

    private void Update()
    {
        if (useHearts)
        {
            if (HP <= 0)
            {
                ++emptyHearts;
                HP = MaxHP;
            }
        }
    }
}
