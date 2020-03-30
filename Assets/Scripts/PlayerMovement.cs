using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MOVE_SPEED = 4f;
    [SerializeField] private int JUMP_VELOCITY = 9;

    private float moveX = 0f;
    private Rigidbody2D rb;
    public Animator animator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private LayerMask GroundLayerMask;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        
    }

    private void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * MOVE_SPEED, rb.velocity.y);
    }

    private void Update()
    {
        //move right
        if (moveX > 0)
        {           
            spriteRenderer.flipX = false;
            animator.SetFloat("Speed", Mathf.Abs(moveX));
            //animator.Play("Run_anim");
        }

        //move left
        else if (moveX < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetFloat("Speed", Mathf.Abs(moveX));
            //animator.Play("Run_anim");
        }

        else
        {
            //animator.SetFloat("Speed", 0);
        }

        if (OnLand() && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * JUMP_VELOCITY;
            animator.SetBool("IsJumping", true);
            //animator.Play("Jump_anim");
        }

        else
        {
            animator.SetBool("IsJumping", false);
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
