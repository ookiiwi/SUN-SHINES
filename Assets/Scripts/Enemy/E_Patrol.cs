﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Patrol : MonoBehaviour
{
    private float initDelay = 5f;
    private float delay;
    private bool delayPasse = true;

    public EnemyAI enemyAI;
    public EnemyController enemyController;

    private Animator animator;
    private Rigidbody2D rb;

    private float dist;
    private float moveSpeed;

    public enum PatrolState
    {
        Idle,
        SearchRight,
        SearchLeft
    };

    public PatrolState patrolState;
    
    private void Start()
    {
        delay = initDelay;
        dist = enemyAI.dist;
        moveSpeed = enemyAI.moveSpeed;

        animator = enemyAI.animator;
        rb = enemyAI.rb;

        patrolState = PatrolState.Idle;
    }

    public void SearchTarget(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            enemyAI.state = EnemyAI.State.Chase;
            animator.SetBool("IsRunning", true);

            return;
        }

        if (delayPasse)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    patrolState = PatrolState.Idle;
                    break;

                case 1:
                    patrolState = PatrolState.SearchLeft;
                    break;

                case 2:
                    patrolState = PatrolState.SearchRight;
                    break;
            }
        }

        if (delay > 0)
        {
            delay -= Time.deltaTime;
            delayPasse = false;
        }
        else
        {
            delay = initDelay;
            delayPasse = true;
        }

        switch (patrolState)
        {
            case PatrolState.Idle:
                {
                    animator.SetBool("IsRunning", false);
                    Debug.Log("Patrol idle");
                    break;
                }

            case PatrolState.SearchLeft:
                {
                    animator.SetBool("IsRunning", true);
                    enemyController.move(enemyAI.rb, -moveSpeed / 2);
                    enemyAI.dist = enemyAI.dist < 0 ? enemyAI.dist : -enemyAI.dist;

                    Debug.Log("Patrol search left");

                    break;
                }

            case PatrolState.SearchRight:
                {
                    animator.SetBool("IsRunning", true);
                    enemyController.move(rb, moveSpeed / 2);
                    enemyAI.dist = enemyAI.dist > 0 ? enemyAI.dist : -enemyAI.dist;

                    Debug.Log("Patrol search right");

                    break;
                }
        }
    }
}
