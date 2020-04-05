using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public PlayerMovement pM;

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
        if (Input.GetAxis("Horizontal") != 0)
        {
            state = State.Run;
        }

        else
        {
            state = State.Idle;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            state = State.Jump;
        }

        else
        {
            pM.animator.SetBool("IsJumping", false);
        }

        Behavior();
    }

    private void Behavior()
    {
        switch(state)
        {
            case State.Idle:
                {


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

                    break;
                }
            
            case State.Attack:
                {

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
