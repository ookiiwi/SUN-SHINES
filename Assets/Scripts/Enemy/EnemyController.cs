using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool facingRight = true;

    public void Move(Rigidbody2D rb, float dir)
    {
        rb.velocity = new Vector2(dir, rb.transform.position.y);

        if (dir < 0 && facingRight)
        {
            FlipX(rb);
        }

        else if (dir > 0 && !facingRight)
        {
            FlipX(rb);
        }
    }

    private void FlipX(Rigidbody2D rb)
    {
        facingRight = !facingRight;

        rb.transform.Rotate(0f, 180f, 0f);
    }
}
