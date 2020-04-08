using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_CheckBack : MonoBehaviour
{
    public E_Patrol e_Patrol;
    public EnemyAI enemyAI;
    private float direction;
    public LayerMask layer;
    private RaycastHit2D checkBack;
    private bool stopCheck = false;

    private void FixedUpdate()
    {
        direction = Mathf.Sign(enemyAI.dir.x) < 1 ? enemyAI.dir.x : -enemyAI.dir.x;

        checkBack = Physics2D.Linecast(transform.position, new Vector2(direction + 2, 0), layer);

        if (checkBack.collider != null && !stopCheck)
        {
            switch (e_Patrol.patrolState)
            {
                case E_Patrol.PatrolState.Idle:
                    {
                        break;
                    }

                case E_Patrol.PatrolState.SearchLeft:
                    {
                        e_Patrol.patrolState = E_Patrol.PatrolState.SearchRight;

                        break;
                    }

                case E_Patrol.PatrolState.SearchRight:
                    {
                        e_Patrol.patrolState = E_Patrol.PatrolState.SearchLeft;

                        break;
                    }
            }
            
            stopCheck = true;
            Debug.Log("Hit back");   
        }

        else if (checkBack.collider == null && stopCheck)
        {
            stopCheck = false;

            Debug.Log("Reset stopCheck");
        }

        
        
    }
}
