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
        }

        Heal();
    }


    //Detect if damaged and apply damages is so
    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.CompareTag("Weapon"))
        {
            //apply damage
            if (characterData.HP > 0)
            {
                FireBall weaponData = collision.gameObject.GetComponent<FireBall>();
                characterData.HP -= weaponData.m_DP;
            }

            animator.SetTrigger("IsHurt");
        }
    }

    private void Heal()
    {
        if (characterData.potionUsed != null)
        {
            switch (characterData.potionUsed.type)
            {
                case PotionSO.Type.Heal:
                    {
                        for(int i = 0; i < characterData.potionUsed.m_gain; ++i)
                        {
                            if (characterData.emptyHearts >= 0 && characterData.HP < characterData.MaxHP)
                            {
                                ++characterData.HP;
                            }

                            else if (characterData.HP > characterData.MaxHP && characterData.emptyHearts > 0)
                            {
                                if (characterData.emptyHearts > 0) --characterData.emptyHearts;

                                characterData.HP = 1;
                            }

                            else
                            {
                                break;
                            }
                        }

                        characterData.potionUsed = null;

                        break;
                    }

                case PotionSO.Type.Power:
                    {
                        characterData.potionUsed = null;

                        break;
                    }

                case PotionSO.Type.Speed:
                    {
                        characterData.potionUsed = null;

                        break;
                    }
            }
        }
    }

    private IEnumerator Die()
    {
        animator.SetTrigger("Death");

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
