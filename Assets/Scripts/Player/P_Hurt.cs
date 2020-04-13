using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Hurt : StateMachineBehaviour
{
    private PlayerManager playerManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        playerManager = animator.GetComponent<PlayerManager>();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxis("Horizontal") != 0 && !playerManager.isAI)
        {
            animator.SetBool("IsRunning", true);
        }
    }
}
