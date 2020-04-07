using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBlack : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private PlayerHealth pHealth;

    public int DP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * moveSpeed;
        pHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroy " + collision.name);

        if (collision.CompareTag("Player"))
        {
            //pHealth.Hurt(DP);          
        } 

        Destroy(gameObject);         
    }

}
