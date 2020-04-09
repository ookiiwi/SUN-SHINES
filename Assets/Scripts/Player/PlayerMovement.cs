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
    private bool facingRight = true;
    private RaycastHit2D groundCheck;
    public BoxCollider2D b_collider;
    private float extraHeight = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //b_collider = GetComponent<Boxb_collider2D>();
    }

    private void FixedUpdate()
    {
        groundCheck = Physics2D.BoxCast(b_collider.bounds.center, b_collider.bounds.size, 0, transform.position, extraHeight, GroundLayerMask);
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
        }
    }

    public void Jump()
    {
        if (OnLand())
        {
            rb.velocity = new Vector2(rb.velocity.normalized.x, Vector2.up.y) * JUMP_VELOCITY;
            
            Debug.Log("Jumping");
        }
    }

    public bool OnLand()
    {
        Color rayColor = Color.green;

        Vector3 b_colliderExtents = new Vector3(b_collider.bounds.extents.x + extraHeight, b_collider.bounds.extents.y + extraHeight);

        if (groundCheck.collider)
        {
            rayColor = Color.red;
        }

        //bottom
        Debug.DrawLine(b_collider.bounds.center - b_colliderExtents, b_collider.bounds.center + new Vector3(b_colliderExtents.x, -b_colliderExtents.y), rayColor);

        //right
        Debug.DrawLine(b_collider.bounds.center + b_colliderExtents, b_collider.bounds.center + new Vector3(b_colliderExtents.x, -b_colliderExtents.y), rayColor);

        //left
        Debug.DrawLine(b_collider.bounds.center - b_colliderExtents, b_collider.bounds.center + new Vector3(-b_colliderExtents.x, b_colliderExtents.y), rayColor);

        return groundCheck.collider;
    }

    private void FlipX()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
