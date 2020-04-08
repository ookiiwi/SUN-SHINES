using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ChaseTarget : MonoBehaviour
{
    public EnemyAI enemyAI;
    public EnemyController enemyController;
    public E_Patrol e_Patrol;

    public void ChaseTarget(RaycastHit2D hit, RaycastHit2D inRange)
    {
        if (hit.collider == null)
        {
            enemyAI.state = EnemyAI.State.Patrol;
            enemyAI.animator.SetBool("IsRunning", false);

            return;
        }

        if (inRange.collider != null) 
        {
            enemyAI.state = EnemyAI.State.Attack;
            enemyAI.animator.SetBool("IsRunning", false);

            return;
        }
        
        enemyController.Move(enemyAI.rb, e_Patrol.moveSpeed);
    }
}
