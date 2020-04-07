using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private EnemyAI enemyAI;

    public int DP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * moveSpeed;
        enemyAI = FindObjectOfType<EnemyAI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroy " + collision.name);

        if (collision.CompareTag("Enemy"))
        {
            enemyAI.Hurt(DP); 
        }
        
        Destroy(gameObject);           
    }

}
