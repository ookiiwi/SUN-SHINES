using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Push : StateMachineBehaviour
{
    private PlayerMovement playerMovement;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerMovement = animator.GetComponent<PlayerMovement>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxis("Horizontal") == 0)
            animator.SetBool("IsPushing", false);

        playerMovement.Run(Input.GetAxis("Horizontal"));
    }
}
