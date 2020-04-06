using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public PlayerMovement pM;
    public PlayerAttack pAttack;
    public Animator animator;

    public enum State
    {
        Idle,
        Run,
        Jump,
        Attack,
        Hurt,
        Die
    };

    public State state;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && pM.OnLand())
        {
            state = State.Run;
            animator.SetBool("IsRunning", true);
        }

        else if (pM.OnLand())
        {
            state = State.Idle;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = State.Jump;
        }

        else
        {
            pM.animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            state = State.Attack;
        }

        Behavior();
    }

    private void Behavior()
    {
        switch(state)
        {
            case State.Idle:
                {
                    animator.SetBool("IsRunning", false);

                    break;
                }
            
            case State.Run:
                {
                    pM.Run(Input.GetAxis("Horizontal"));
                    
                    break;
                }
            
            case State.Jump:
                {
                    pM.Jump();
                    animator.SetBool("IsRunning", false);
                    animator.SetBool("IsJumping", true);

                    break;
                }
            
            case State.Attack:
                {
                    animator.SetTrigger("Attack");
                    pAttack.Attack();

                    break;
                }
            
            case State.Hurt:
                {

                    break;
                }
            
            case State.Die:
                {

                    break;
                }
        }
    }
}
