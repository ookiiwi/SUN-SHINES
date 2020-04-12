using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Attack : StateMachineBehaviour
{
    private Transform firePoint;
    public GameObject fireBall;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        firePoint = animator.gameObject.transform.Find("FirePoint");
        Instantiate(fireBall, firePoint.position, firePoint.rotation);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("IsRunning", true);
        }
    }
}
