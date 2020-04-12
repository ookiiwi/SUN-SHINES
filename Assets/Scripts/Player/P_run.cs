using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_run : StateMachineBehaviour
{
    private PlayerMovement playerMovement;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        playerMovement = animator.GetComponent<PlayerMovement>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }

        else if (Input.GetAxis("Horizontal") != 0)
        {
            playerMovement.Run(Input.GetAxis("Horizontal"));
        }


        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("IsRunning", false);
    }
}
