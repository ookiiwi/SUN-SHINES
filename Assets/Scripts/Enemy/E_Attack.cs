using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Attack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireBall;

    public EnemyAI enemyAI;

    public float initDelayAttacks;
    static private float delayBetweenAttacks = 0;

    public void Attack()
    {
        if (delayBetweenAttacks <= 0)
        {
            delayBetweenAttacks = initDelayAttacks;

            enemyAI.animator.SetBool("Attack", true);
            Instantiate(fireBall, firePoint.position, firePoint.rotation);

            Debug.Log("Instantiate black fireBall");
        }

        else
        {
            delayBetweenAttacks -= Time.deltaTime;
        }

        enemyAI.state = EnemyAI.State.Attack;
    }
}
