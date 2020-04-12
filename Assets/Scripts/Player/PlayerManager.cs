using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator animator;
    public float initDelayAttacks;
    private float delayAttacks;

    private void Start()
    {
        delayAttacks = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && delayAttacks <= 0)
        {
            animator.SetTrigger("Attack");

            delayAttacks = initDelayAttacks;
        }

        else if (delayAttacks > 0)
        {
            delayAttacks -= Time.deltaTime;
        }
    }
}
