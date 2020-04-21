using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ChaseTarget : StateMachineBehaviour
{
    public float moveSpeed;
    private EnemyController enemyController;
    private E_CheckForTarget checkForTarget;
    private float dir;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        enemyController = animator.GetComponent<EnemyController>();
        checkForTarget = animator.GetComponentInChildren<E_CheckForTarget>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        dir = Mathf.Sign(checkForTarget.chaseDist.x) * 1;

        enemyController.Move(dir * moveSpeed);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("IsChasing", false);
    }
}
