using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float dist = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private float initDelay = 5f;
    [SerializeField] private LayerMask playerLayer;
    private Transform target;
    private Rigidbody2D rb2d;
    private EnemyController controller;
    private float delay;
    private bool delayPasse = true;
    private RaycastHit2D hit;
    private Vector2 dir;
    public Transform firePoint;
    public GameObject fireBall;
    public float initDelayAttacks;
    private float delayBetweenAttacks = 0;

    [SerializeField] private float HP;

    public enum State
    {
        Patrol,
        Chase,
        Attack
    };

    private enum PatrolState
    {
        Idle, 
        SearchRight,
        SearchLeft
    };

    public State state;
    private PatrolState patrolState;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        controller = new EnemyController();

        state = State.Patrol;
        patrolState = PatrolState.Idle;

        delay = initDelay;

        dir = new Vector2(transform.position.x - dist, transform.position.y);
    }


    private void FixedUpdate()
    {
        dir = new Vector2(transform.position.x + dist, transform.position.y);
        hit = Physics2D.Linecast(transform.position, dir, playerLayer);

        if (hit.collider != null)
        {
            Debug.Log("Target found");
            Debug.Log("hit: " + hit.collider.name);
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }

        else
        {
            Debug.DrawLine(transform.position, dir, Color.green);
        }


        Behaviour();


    }

    private void Behaviour()
    {        
        switch (state)
        {
            case State.Patrol:
                {
                    SearchTarget(hit);

                    break;
                }


            case State.Chase:
                {
                    ChaseTarget(hit);

                    Debug.Log("Chase state");
                    break;
                }

            case State.Attack:
                {
                    Attack();
                    Debug.Log("Attack state");
                    break;
                }
        }
        

        //Debug.Log("Routine called");

    }
    

    private void SearchTarget(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            state = State.Chase;
            animator.SetBool("IsRunning", true);

            return;
        }

        if (delayPasse)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    patrolState = PatrolState.Idle;
                    break;

                case 1:
                    patrolState = PatrolState.SearchLeft;
                    break;

                case 2:
                    patrolState = PatrolState.SearchRight;
                    break;
            }
        }

        if (delay > 0)
        {
            delay -= Time.deltaTime;
            delayPasse = false;
        }
        else
        {
            delay = initDelay;
            delayPasse = true;
        }

        switch (patrolState)
        {
            case PatrolState.Idle:
            {
                animator.SetBool("IsRunning", false);
                Debug.Log("Patrol idle");
                break;
            }

            case PatrolState.SearchLeft:
            {
                animator.SetBool("IsRunning", true);
                controller.move(rb2d, -moveSpeed / 2);
                dist = dist < 0 ? dist : -dist;

                Debug.Log("Patrol search left");

                break;
            }

            case PatrolState.SearchRight:
            {
                animator.SetBool("IsRunning", true);
                controller.move(rb2d, moveSpeed / 2);
                dist = dist > 0 ? dist : -dist;

                Debug.Log("Patrol search right");

                break;
            }
        }
    }



    private void ChaseTarget(RaycastHit2D hit)
    {
        controller.move(rb2d, moveSpeed * dir.normalized.x);      

        if (hit.collider == null)
        {
            
            state = State.Patrol;
            animator.SetBool("IsRunning", false);

            return;
        }

        if (Mathf.Abs(transform.position.x - target.position.x) < 2f)
        {
            state = State.Attack;
            animator.SetBool("IsRunning", false);
            

            return;
        }
    }

    private void Attack()
    {
        if (Mathf.Abs(transform.position.x - target.position.x) > 2f)
        {
            state = State.Chase;
            animator.SetBool("Attack", false);
            animator.SetBool("IsRunning", true);

            return;
        }

        if (delayBetweenAttacks <= 0)
        {
            delayBetweenAttacks = initDelayAttacks;

            animator.SetBool("Attack", true);
            Instantiate(fireBall, firePoint.position, firePoint.rotation);

            Debug.Log("Instantiate black fireBall");
        }

        else
        {
            delayBetweenAttacks -= Time.deltaTime;
        }

        state = State.Attack;   
    }

    public void Hurt(int DP)
    {
        HP -= DP;
        animator.SetTrigger("IsHurt");
        controller.move(rb2d, 0 * dir.normalized.x);

        Debug.Log("Hurt() called");

        if (HP <= 0)
        {
            Die();
            return;
        }

        state = State.Patrol;
        Debug.Log("Hurt");
    }
    
    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("Dying");
    }
}
