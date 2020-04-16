using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private GameManager gameManager;
    public Animator animator;

    private RaycastHit2D hit;
    private RaycastHit2D hit2;
    private RaycastHit2D hit3;
    private RaycastHit2D hit4;
    private RaycastHit2D hit5;
    private RaycastHit2D hit6;
    public Vector3 dist;
    public Vector3 offset;

    public LayerMask layers;

    private BoxCollider2D boxCollider;

    public bool follow;
    public bool followlow = true;

    private void Start()
    {

        boxCollider = GetComponent<BoxCollider2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {
        //bottom 1
        hit = Physics2D.Linecast(transform.position + new Vector3(-boxCollider.bounds.extents.x, -boxCollider.bounds.extents.y * 2), transform.position + new Vector3(-boxCollider.bounds.extents.x, -boxCollider.bounds.extents.y * 2) + dist, layers);
        
        //middle forward
        hit2 = Physics2D.Linecast(transform.position + offset, transform.position + offset + dist, layers);

        //top forward
        hit3 = Physics2D.Linecast(transform.position + new Vector3(offset.x, boxCollider.bounds.extents.y), transform.position + new Vector3(offset.x, boxCollider.bounds.extents.y) + dist, layers);

        //top 1
        hit4 = Physics2D.Linecast(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 2), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 2) + dist * 2, layers);

        //top 2
        hit5 = Physics2D.Linecast(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 3), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 3) + dist * 2, layers);

        //top 3
        hit6 = Physics2D.Linecast(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 4), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 4) + dist * 2, layers);

        if ( (hit.collider != null || hit2.collider != null || hit3.collider != null || hit4.collider != null || hit5.collider != null || hit6.collider != null) && !followlow)
        {
            //bottom 1
            Debug.DrawLine(transform.position + new Vector3(-boxCollider.bounds.extents.x, -boxCollider.bounds.extents.y * 2), transform.position + new Vector3(-boxCollider.bounds.extents.x, -boxCollider.bounds.extents.y * 2) + dist, Color.yellow);
            
            // middle
            Debug.DrawLine(transform.position + offset, transform.position + offset + dist, Color.yellow);
            
            //top forward
            Debug.DrawLine(transform.position + new Vector3(offset.x, boxCollider.bounds.extents.y), transform.position + new Vector3(offset.x, boxCollider.bounds.extents.y) + dist, Color.yellow);
            
            //top 1
            Debug.DrawLine(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 2), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 2) + dist * 2, Color.yellow);
            
            //top 2
            Debug.DrawLine(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 3), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 3) + dist * 2, Color.yellow);
            
            //top 3
            Debug.DrawLine(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 4), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 4) + dist * 2, Color.yellow);
            if (hit6.collider != null) Debug.Log("top 3:" + hit6.collider.gameObject.name);

            animator.SetBool("IsRunning", false);

            if ( hit2.collider != null && hit2.collider.gameObject != gameManager.currentPlayer || hit3.collider != null && hit3.collider.gameObject != gameManager.currentPlayer)
            {
                follow = true;
            }

            else if (hit4.collider != null && hit4.collider.gameObject != gameManager.currentPlayer || hit5.collider != null && hit5.collider.gameObject != gameManager.currentPlayer 
                    || hit6.collider != null && hit6.collider.gameObject != gameManager.currentPlayer)
            {
                follow = true;
            }
        }
        
        else if (gameManager.currentPlayer != null)
        {
            //bottom 1
            Debug.DrawLine(transform.position + new Vector3(-boxCollider.bounds.extents.x, -boxCollider.bounds.extents.y * 2), transform.position + new Vector3(-boxCollider.bounds.extents.x, -boxCollider.bounds.extents.y * 2) + dist, Color.green);
            
            //middle
            Debug.DrawLine(transform.position + offset, transform.position + offset + dist, Color.green);
            //Debug.DrawLine(transform.position + offset + dist, transform.position + offset + dist + dist / 2, Color.red);
            
            //top forward
            Debug.DrawLine(transform.position + new Vector3(offset.x, boxCollider.bounds.extents.y), transform.position + new Vector3(offset.x, boxCollider.bounds.extents.y) + dist, Color.green);
            
            //top 1
            Debug.DrawLine(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 2), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 2) + dist * 2, Color.green);
        
            //top 2
            Debug.DrawLine(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 3), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 3) + dist * 2, Color.green);
        
            //top 3
            Debug.DrawLine(transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 4), transform.position + new Vector3(-boxCollider.bounds.extents.x, boxCollider.bounds.extents.y * 4) + dist * 2, Color.green);


            //go right
            if (transform.position.x + boxCollider.bounds.extents.x < gameManager.currentPlayer.transform.position.x)
            {
                animator.SetBool("IsRunning", true);
                playerMovement.Run(1);

                dist.x = Mathf.Abs(dist.x);
                offset.x = Mathf.Abs(offset.x);
            }

            //go left
            else if (transform.position.x - boxCollider.bounds.extents.x > gameManager.currentPlayer.transform.position.x)
            {
                animator.SetBool("IsRunning", true);
                playerMovement.Run(-1);

                dist.x = Mathf.Abs(dist.x) * -1;
                offset.x = Mathf.Abs(offset.x) * -1;
            }
        }

        if (hit2.collider != null && hit2.collider.gameObject == gameManager.currentPlayer || hit3.collider != null && hit3.collider.gameObject == gameManager.currentPlayer)
        {
            follow = false;
        }

        else if (hit4.collider != null && hit4.collider.gameObject == gameManager.currentPlayer || hit5.collider != null && hit5.collider.gameObject == gameManager.currentPlayer
                    || hit6.collider != null && hit6.collider.gameObject == gameManager.currentPlayer)
        {
            follow = false;
        }

        Debug.Log("followlow = " + followlow);
    }
}
