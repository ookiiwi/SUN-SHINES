﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ChaseTarget : MonoBehaviour
{
    private Transform target;

    public EnemyAI enemyAI;
    public EnemyController enemyController;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void ChaseTarget(RaycastHit2D hit, RaycastHit2D inRange)
    {
        enemyController.move(enemyAI.rb, enemyAI.moveSpeed * enemyAI.dir.normalized.x);

        if (hit.collider == null)
        {

            enemyAI.state = EnemyAI.State.Patrol;
            enemyAI.animator.SetBool("IsRunning", false);

            return;
        }

        if (inRange.collider != null) 
        {
            enemyAI.state = EnemyAI.State.Attack;
            enemyAI.animator.SetBool("IsRunning", false);

            return;
        }
    }
}
