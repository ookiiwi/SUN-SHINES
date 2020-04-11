using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Patrol : StateMachineBehaviour
{
    private EnemyController enemyController;
    private E_CheckForTarget checkForTarget;
    private int random;
    private int dir = 1;
    public float moveSpeed;
    public float initAnimTime;
    private float animTime;
    private bool prevRight = false;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyController = animator.GetComponent<EnemyController>();

        animTime = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /****Patrol routine****/
        if (animTime <= 0)
        {
            random = Random.Range(0, 3);
            if (random == 2)
                animator.SetBool("IsPatrolling", false);

            animTime = initAnimTime;
            prevRight = !prevRight;
        }

        else
        {
            animTime -= Time.deltaTime;
        }
        
        // go right
        if (!prevRight && animTime >= 0)
        {
            
            enemyController.Move(dir * moveSpeed);
        }

        //go left
        else if (prevRight && animTime >= 0)
        {
            enemyController.Move(-dir * moveSpeed);
        }

        /****Patrol Routine****/
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("IsPatrolling", false);
    }
}
