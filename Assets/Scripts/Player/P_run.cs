using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_run : StateMachineBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerManager playerManager;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        playerMovement = animator.GetComponent<PlayerMovement>();
        playerManager = animator.GetComponent<PlayerManager>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playerManager.isAI)
        {
            animator.SetBool("IsJumping", true);
        }

        else if (Input.GetAxis("Horizontal") != 0 && !playerManager.isAI)
        {
            playerMovement.Run(Input.GetAxis("Horizontal"));
        }


        else if (!playerManager.isAI)
        {
            animator.SetBool("IsRunning", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("IsRunning", false);
    }
}
