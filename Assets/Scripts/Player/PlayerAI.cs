using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public PlayerManager playerManager;
    public PlayerMovement playerMovement;

    public Vector3 dist;
    public Vector3 rayOffset;
    private RaycastHit2D hit;

    private enum State
    {
        Follow,
        Attack
    }

    private State state;

    private void FixedUpdate()
    {
        if (playerManager.isAI)
        {
            hit = Physics2D.Linecast(transform.position + rayOffset, transform.position + dist);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                Debug.DrawLine(transform.position + rayOffset, transform.position + dist, Color.yellow);

                //stop
            }

            else
            {
                Debug.DrawLine(transform.position + rayOffset, transform.position + dist, Color.green);

                //go ahead and follow main player
            }
        }
    }

    private void Behaviour()
    {
        switch(state)
        {
            case State.Follow:
                {

                    break;
                }

            case State.Attack:
                {

                    break;
                }
        }
    }
}
