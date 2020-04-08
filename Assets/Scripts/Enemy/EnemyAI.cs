using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed;
    public float dist;
    public float attackrange;

    public Animator animator;
    [SerializeField] private LayerMask playerLayer;

    public E_Attack e_Attack;
    public E_ChaseTarget e_ChaseTarget;
    public E_Patrol e_Patrol;
    public E_Health e_Health;

    public Rigidbody2D rb;

    public RaycastHit2D hit;
    private RaycastHit2D inAttackRange;
    [HideInInspector] public Vector2 dir;
   

    public enum State
    {
        Patrol,
        Chase,
        Attack
    };

    public State state;
    

    private void Start()
    {   
        state = State.Patrol;

        dir = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        dir = new Vector2(transform.position.x, transform.position.y);
    }


    private void FixedUpdate()
    { 
        hit = Physics2D.Linecast(transform.position, dir + new Vector2(dist, 0), playerLayer);
        inAttackRange = Physics2D.Linecast(transform.position, dir + new Vector2(attackrange, 0), playerLayer);

        if (hit.collider != null)
        {
            Debug.Log("Target found");
            Debug.Log("hit: " + hit.collider.name);
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }

        else
        {
            Debug.DrawLine(transform.position, dir + new Vector2(attackrange, 0), Color.green);
        }

        Behaviour();
    }

    private void Behaviour()
    {        
        switch (state)
        {
            case State.Patrol:
                {
                    e_Patrol.SearchTarget(hit);

                    break;
                }


            case State.Chase:
                {
                    e_ChaseTarget.ChaseTarget(hit, inAttackRange);

                    Debug.Log("Chase state");
                    break;
                }

            case State.Attack:
                {
                    e_Attack.Attack(inAttackRange);
                    Debug.Log("Attack state");
                    break;
                }
        }
    }
}
