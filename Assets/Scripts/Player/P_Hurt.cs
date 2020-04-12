using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Hurt : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("IsRunning", true);
        }
    }
}
