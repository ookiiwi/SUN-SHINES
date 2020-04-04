using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    public void move(Rigidbody2D rb, float dir)
    {
        rb.velocity = new Vector2(dir, rb.transform.position.y);

        if (dir < 0)
        {
            rb.GetComponent<SpriteRenderer>().flipX = true;
        }

        else
        {
            rb.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
