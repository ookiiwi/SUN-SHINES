using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private E_Health e_health;

    public int DP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        Debug.Log("Destroy " + collision.name);

        if (collision.CompareTag("Enemy"))
        {
            e_health = collision.gameObject.GetComponent<E_Health>();
            e_health.Hurt(DP); 
        }
        
        Destroy(gameObject);           
    }

}
