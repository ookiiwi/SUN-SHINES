using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_CheckForTarget : MonoBehaviour
{
    public Animator animator;
    public EnemyController enemyController;

    public bool goOpposite = false;

    public LayerMask targetLayer;
    public LayerMask friendLayer;

    private RaycastHit2D chaseZone;
    private RaycastHit2D chaseZone2;
    private RaycastHit2D chaseZone3;
    private RaycastHit2D attackZone;
    private RaycastHit2D attackZone2;
    private RaycastHit2D attackZone3;
    private RaycastHit2D friendZone;

    public Vector3 chaseDist;
    public Vector3 attackDist;
    public Vector3 friendRayOffset;
    private Vector3 rayOffsetY;

    private float extentsY;

    private void Start()
    {
        extentsY = GetComponentInParent<BoxCollider2D>().bounds.extents.y;
        rayOffsetY = new Vector3(0f, extentsY);
    }

    private void Update()
    {
        if (!enemyController.facingRight)
        {
            chaseDist = chaseDist.x < 0 ? chaseDist : -chaseDist;
            attackDist = attackDist.x < 0 ? attackDist : -attackDist;
            friendRayOffset = friendRayOffset.x < 0 ? friendRayOffset : -friendRayOffset;
        }
        
        else if (enemyController.facingRight)
        {
            chaseDist = chaseDist.x > 0 ? chaseDist : -chaseDist;
            attackDist = attackDist.x > 0 ? attackDist : -attackDist;
            friendRayOffset = friendRayOffset.x > 0 ? friendRayOffset : -friendRayOffset;
        }
    }


    private void FixedUpdate()
    {
        chaseZone = Physics2D.Linecast(transform.position + attackDist, transform.position + chaseDist, targetLayer);

        chaseZone2 = Physics2D.Linecast(transform.position + rayOffsetY + attackDist, transform.position + rayOffsetY + chaseDist, targetLayer);

        chaseZone3 = Physics2D.Linecast(transform.position - rayOffsetY + attackDist, transform.position  - rayOffsetY + chaseDist, targetLayer);
        
        attackZone = Physics2D.Linecast(transform.position, transform.position + attackDist, targetLayer);

        attackZone2 = Physics2D.Linecast(transform.position + rayOffsetY, transform.position + rayOffsetY + attackDist, targetLayer);

        attackZone3 = Physics2D.Linecast(transform.position - rayOffsetY, transform.position - rayOffsetY + attackDist, targetLayer);

        friendZone = Physics2D.Linecast(transform.position + friendRayOffset, transform.position + attackDist, friendLayer);

        Check();
    }

    private void Check()
    {
        

        if (friendZone.collider != null)
        {
            Debug.DrawLine(transform.position + friendRayOffset, transform.position + attackDist, Color.blue);

            Debug.Log("Friend");

            goOpposite = true;

            animator.SetBool("IsPatrolling", true);

            return;
        }

        //attack zone
        if (attackZone.collider != null || attackZone2.collider != null || attackZone3.collider != null)
        {
            Debug.DrawLine(transform.position, transform.position + attackDist, Color.cyan);

            Debug.DrawLine(transform.position + rayOffsetY, transform.position + rayOffsetY + attackDist, Color.cyan);

            Debug.DrawLine(transform.position - rayOffsetY, transform.position - rayOffsetY + attackDist, Color.cyan);


            animator.SetBool("IsAttacking", true);
            return;
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position + attackDist, Color.yellow);

            Debug.DrawLine(transform.position + rayOffsetY, transform.position + rayOffsetY + attackDist, Color.yellow);

            Debug.DrawLine(transform.position - rayOffsetY, transform.position - rayOffsetY + attackDist, Color.yellow);


            animator.SetBool("IsAttacking", false);
        }

        //chase zone
        if (chaseZone.collider != null || chaseZone2.collider != null || chaseZone3.collider != null)
        {
            Debug.DrawLine(transform.position + attackDist, transform.position + chaseDist, Color.red);

            Debug.DrawLine(transform.position + rayOffsetY + attackDist, transform.position + rayOffsetY + chaseDist, Color.red);

            Debug.DrawLine(transform.position - rayOffsetY + attackDist, transform.position - rayOffsetY + chaseDist, Color.red);

            animator.SetBool("IsChasing", true);

            return;
        }

        else
        {
            Debug.DrawLine(transform.position + attackDist, transform.position + chaseDist, Color.green);

            Debug.DrawLine(transform.position + rayOffsetY + attackDist, transform.position + rayOffsetY + chaseDist, Color.green);

            Debug.DrawLine(transform.position - rayOffsetY + attackDist, transform.position - rayOffsetY + chaseDist, Color.green);

            animator.SetBool("IsChasing", false);
        }


     
    }
}
