using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool isAI;
    public Animator animator;

    private PlayerMovement playerMovement;
    private GameManager gameManager;

    public float initDelayAttacks;
    private float delayAttacks;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        delayAttacks = 0;
    }

    private void Update()
    {
        if (!isAI)
        {
            gameObject.GetComponent<PlayerAI>().enabled = false;

            if (Input.GetKeyDown(KeyCode.A) && delayAttacks <= 0 && gameManager.isInputEnabled)
            {
                animator.SetTrigger("Attack");

                delayAttacks = initDelayAttacks;
            }

            else if (delayAttacks > 0)
            {
                delayAttacks -= Time.deltaTime;
            }
        }
        
        else
        {
            gameObject.GetComponent<PlayerAI>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAI)
        {
            if (collision.otherCollider.transform.position.x < collision.collider.transform.position.x && playerMovement.facingRight)
            {
                animator.SetBool("IsPushing", true);
            }

            else if (collision.otherCollider.transform.position.x > collision.collider.transform.position.x && !playerMovement.facingRight)
            {
                animator.SetBool("IsPushing", true);
            }
        }
    }
}
