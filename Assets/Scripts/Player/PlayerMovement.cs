using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MOVE_SPEED = 4f;
    [SerializeField] private float JUMP_VELOCITY = 5f;
    [SerializeField] private LayerMask GroundLayerMask;
    private Rigidbody2D rb;
    public Animator animator;
    private BoxCollider2D boxCollider2D;
    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();

    }

    public void Run(float moveX)
    {
        if (OnLand())
        {
            rb.velocity = new Vector2(moveX * MOVE_SPEED, rb.velocity.y);

            if (moveX > 0 && !facingRight)
            {
                FlipX();
            }

            else if (moveX < 0 && facingRight)
            {
                FlipX();
            }
            //animator.SetBool("IsRunning", true);
            
        }
    }

    public void Jump()
    {
        if (OnLand())
        {
            //animator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.normalized.x, Vector2.up.y) * JUMP_VELOCITY;
            
            Debug.Log("Jumping");
        }
    }

    public bool OnLand()
    {
        if (boxCollider2D.IsTouchingLayers(GroundLayerMask))
        {
            //Debug.Log("OnLand");
            return true;
        }

        //Debug.Log("!OnLand");
        return false;
    }

    private void FlipX()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
