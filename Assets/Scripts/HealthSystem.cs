using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public CharacterData characterData;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (characterData.useHearts)
        {
            if (characterData.emptyHearts >= characterData.hearts)
            {
                StartCoroutine(Die());
            }
        }

        else if (characterData.HP <= 0)
        {
            StartCoroutine(Die());

            Debug.Log("Die");
        }
    }


    //Detect if damaged and apply damages is so
    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.CompareTag("Weapon"))
        {
            if (characterData.HP > 0)
            {
                FireBall weaponData = collision.gameObject.GetComponent<FireBall>();
                characterData.HP -= weaponData.m_DP;
            }

            animator.SetTrigger("IsHurt");
        }
    }

    private IEnumerator Die()
    {
        animator.SetTrigger("Death");

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
