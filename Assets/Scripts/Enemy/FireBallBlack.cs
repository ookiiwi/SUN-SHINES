using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBlack : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private PlayerHealth p_health;

    public int DP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Debug.Log("Destroy " + collision.name);

        if (collision.CompareTag("Player"))
        {
            p_health = collision.gameObject.GetComponent<PlayerHealth>();
            p_health.Hurt(DP); 
            Destroy(gameObject);          
        } 

                
    }

}
