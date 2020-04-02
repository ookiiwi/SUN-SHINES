using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private float dist;
    [SerializeField] private Transform target;
    private Rigidbody2D rb2d;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //dist = Vector2.Distance(transform.position, target.position);
        //if (dist < 10)
        //{
        //    if (transform.position.x < target.position.x)
        //    {
        //        rb2d.velocity = new Vector2(1f * moveSpeed, transform.position.y);
        //        transform.localScale = new Vector2(1, 1);
        //    }
        //
        //    else if (transform.position.x > target.position.x)
        //    {
        //        rb2d.velocity = new Vector2(-1f * moveSpeed, transform.position.y);
        //        transform.localScale = new Vector2(-1, 1);
        //    }
        //
        //    else
        //    {
        //        rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
        //    }
        //
        //    
        //}

        dist = 5;

        RaycastHit2D targetFound = Physics2D.Raycast(transform.position, transform.position + transform.right * dist, dist, 1 << LayerMask.NameToLayer("Player"));
        
        if (targetFound.collider != null)
        {
            if (transform.position.x < target.position.x)
            {
                rb2d.velocity = new Vector2(1f * moveSpeed, transform.position.y);
                transform.localScale = new Vector2(1, 1);
                dist = +dist;
            }

            else if (transform.position.x > target.position.x)
            {
                rb2d.velocity = new Vector2(-1f * moveSpeed, transform.position.y);
                transform.localScale = new Vector2(-1, 1);
                dist = -dist;
            }
            Debug.DrawLine(transform.position, transform.position + transform.right * dist, Color.red);
        } 
        else
        {
            
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
            
            Debug.DrawLine(transform.position, transform.position + transform.right * dist, Color.green);
        }






        //Debug.Log(target.gameObject.name + ": " + gameObject.name + ": " + Time.time);
        //Debug.DrawLine(transform.position, target.transform.position);
        //Debug.DrawLine(transform.position, transform.position + dir, Color.red);
    }
}
