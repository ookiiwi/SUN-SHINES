using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int HP = 100;
    private Animator anim;
    private PlayerBehavior playerBehavior;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    public void Hurt(int DP)
    {
        HP -= DP;
        anim.SetTrigger("Hurt");

        if (HP <= 0)
        {
            Die();

            return;
        }

        playerBehavior.state = PlayerBehavior.State.Idle;
    }

    private IEnumerator Die()
    {
        anim.SetTrigger("Death");

        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
