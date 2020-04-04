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
    private SpriteRenderer sprite;
    private SpriteRenderer targetSprite;
    private EnemyController controller;
    private float delay;
    private bool delayPasse = true;
    private RaycastHit2D hit;
    private Vector2 dir;

    private enum State
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

    private State state;
    private PatrolState patrolState;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        targetSprite = GetComponent<SpriteRenderer>();
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
            //Debug.DrawLine(transform.position, transform.position + transform.right * dist, Color.red);
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

        if (patrolState == PatrolState.Idle)
        {
            animator.SetBool("IsRunning", false);
            Debug.Log("Patrol idle");
        }

        else if (patrolState == PatrolState.SearchLeft)
        {
            animator.SetBool("IsRunning", true);
            controller.move(rb2d, -moveSpeed / 2);
            dist = dist < 0 ? dist : -dist;

            Debug.Log("Patrol search left");
        }

        else if (patrolState == PatrolState.SearchRight)
        {
            animator.SetBool("IsRunning", true);
            controller.move(rb2d, moveSpeed / 2);
            dist = dist > 0 ? dist : -dist;

            Debug.Log("Patrol search right");
        }
    }



    private void ChaseTarget(RaycastHit2D hit)
    {
        if (transform.position.x + sprite.bounds.extents.x < target.position.x - targetSprite.bounds.extents.x)
        {
            controller.move(rb2d, moveSpeed);
            
        }
        
        else if (transform.position.x - sprite.bounds.extents.x > target.position.x + targetSprite.bounds.extents.x)
        {
            controller.move(rb2d, -moveSpeed);
        }

        if (hit.collider == null)
        {
            
            state = State.Patrol;
            animator.SetBool("IsRunning", false);
        }

        if (Mathf.Abs(transform.position.x - target.position.x) < 2f)
        {
            state = State.Attack;
            animator.SetBool("IsRunning", false);
        }
    }

    private void Attack()
    {
        if (Mathf.Abs(transform.position.x - target.position.x) > 2f)
        {            
            state = State.Chase;
            animator.SetBool("Attack", false);
            animator.SetBool("IsRunning", true);
        }

        else
        {
            animator.SetBool("Attack", true);   
        }
            
    }
}
