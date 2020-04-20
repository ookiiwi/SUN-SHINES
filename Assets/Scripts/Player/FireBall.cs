using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    public string m_name;
    public int m_DP;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
            Destroy(gameObject);
    }
}
