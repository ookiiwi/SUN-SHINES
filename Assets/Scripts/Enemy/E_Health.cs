using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Health : MonoBehaviour
{
    public int HP;

    public EnemyAI enemyAI;
    public EnemyController enemyController;
    public E_CheckBack e_CheckBack;
    public HealthBar healthBar;

    public void Hurt(int DP, Transform weapon)
    {
        HP -= DP;

        enemyAI.animator.SetTrigger("IsHurt");
        enemyController.Move(enemyAI.rb, 0 * enemyAI.dir.normalized.x);

        Debug.Log("HP: " + HP);

        if (HP <= 0)
        {
            Die();
            return;
        }

        enemyAI.state = EnemyAI.State.Patrol;

        e_CheckBack.Check(weapon, enemyController.facingRight);

        healthBar.Bar(HP);
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Dying");
    }
}
