using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Attack : StateMachineBehaviour
{
    public GameObject fireBall;
    private Transform firePoint;
    [HideInInspector] public GameObject fireBallInst;
    public float initDelayBetweenAttack;
    private float delayAttack;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        firePoint = animator.transform.Find("Fire Point");
        delayAttack = initDelayBetweenAttack;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (delayAttack <= 0)
        {
            fireBallInst = Instantiate(fireBall, firePoint.position, firePoint.rotation);
            delayAttack = initDelayBetweenAttack;

            Debug.Log("Attack");
        }

        else
        {
            delayAttack -= Time.deltaTime;
        }
    }
}
