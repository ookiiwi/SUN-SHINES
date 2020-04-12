using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Idle : StateMachineBehaviour
{
    private PlayerMovement playerMovement;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        playerMovement = animator.GetComponent<PlayerMovement>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("IsRunning", true);
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
    }
}
