using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Jump : StateMachineBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerManager playerManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerMovement = animator.GetComponent<PlayerMovement>();
        playerManager = animator.GetComponent<PlayerManager>();

        playerMovement.Jump();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerMovement.OnLand())
        {
            animator.SetBool("IsJumping", false);
        }

        playerMovement.Run(Input.GetAxis("Horizontal"));
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (Input.GetAxis("Horizontal") != 0 && !playerManager.isAI)
        {
            animator.SetBool("IsRunning", true);
        }
    }
}
