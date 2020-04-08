﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_CheckBack : MonoBehaviour
{
    public E_Patrol e_Patrol;

    public void Check(Transform weapon, bool facingRight)
    {
        if (transform.position.x > weapon.position.x && facingRight)
        {
            e_Patrol.patrolState = E_Patrol.PatrolState.SearchLeft;
            return; 
        }

        else if (transform.position.x < weapon.position.x && !facingRight)
        {
            e_Patrol.patrolState = E_Patrol.PatrolState.SearchRight;
            return;
        }
    }
}