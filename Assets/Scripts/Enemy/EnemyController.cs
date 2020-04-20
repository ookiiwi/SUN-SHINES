using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool facingRight = true;
    public Rigidbody2D rb;

    public void Move(float dir)
    {
        rb.velocity = new Vector2(dir, rb.velocity.y);

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
