using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MOVE_SPEED = 4f;
    [SerializeField] private int JUMP_VELOCITY = 9;
    [SerializeField] private LayerMask GroundLayerMask;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        
    }

    public void Run(float moveX)
    {
        rb.velocity = new Vector2(moveX * MOVE_SPEED, rb.velocity.y);
        spriteRenderer.flipX = moveX > 0 ? false : true;
        animator.SetFloat("Speed", Mathf.Abs(moveX));
    }

    public void Jump()
    {
        if (OnLand())
        {
            rb.velocity = Vector2.up * JUMP_VELOCITY;
            animator.SetBool("IsJumping", true);
        }
    }

    private bool OnLand()
    {
        if (boxCollider2D.IsTouchingLayers(GroundLayerMask))
        {
            //Debug.Log("OnLand");
            return true;
        }

        //Debug.Log("!OnLand");
        return false;
    }
}
