using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Attack : StateMachineBehaviour
{
    private Transform firePoint;
    public GameObject fireBall;
    private GameObject fireBallInst;
    private FireBall fireBallScript;
    private Animator fireBallAnim;
    public FireBallS_Obj fireBallS_Obj;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        fireBallAnim = fireBall.GetComponent<Animator>();

        firePoint = animator.gameObject.transform.Find("FirePoint");
        fireBallAnim.runtimeAnimatorController = fireBallS_Obj.m_animatorController;

        fireBallInst = Instantiate(fireBall, firePoint.position, firePoint.rotation);
        fireBallScript = fireBallInst.GetComponent<FireBall>();
        fireBallScript.m_name = fireBallS_Obj.m_name;
        fireBallScript.m_DP = fireBallS_Obj.m_DP;

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("IsRunning", true);
        }
    }
}
