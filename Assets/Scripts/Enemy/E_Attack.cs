﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Attack : StateMachineBehaviour
{
    public GameObject fireBall;
    private FireBall fireBallScript;
    private Transform firePoint;
    private Animator fireBallAnim;
    public FireBallS_Obj fireBallS_Obj;
    [HideInInspector] public GameObject fireBallInst;
    public float initDelayBetweenAttack;
    private float delayAttack;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        fireBallAnim = fireBall.GetComponent<Animator>();
        fireBallAnim.runtimeAnimatorController = fireBallS_Obj.m_animatorController;

        firePoint = animator.transform.Find("Fire Point");
        delayAttack = initDelayBetweenAttack;

        Attack();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (delayAttack <= 0)
        {
            Attack();
        }

        else
        {
            delayAttack -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        fireBallInst = Instantiate(fireBall, firePoint.position, firePoint.rotation);
        fireBallScript = fireBallInst.GetComponent<FireBall>();
        fireBallScript.m_name = fireBallS_Obj.m_name;
        fireBallScript.m_DP = fireBallS_Obj.m_DP;
        delayAttack = initDelayBetweenAttack;

        Debug.Log("Attack");
        Debug.Log("delay: " + delayAttack);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("IsAttacking", false);
    }
}
