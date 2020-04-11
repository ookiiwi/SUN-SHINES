using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Idle : StateMachineBehaviour
{
    public float initDelay;
    private float delay;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        delay = initDelay;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (delay <= 0)
        {
            animator.SetBool("IsPatrolling", true);
            delay = initDelay;
        }

        else
            delay -= Time.deltaTime;


    }
}
