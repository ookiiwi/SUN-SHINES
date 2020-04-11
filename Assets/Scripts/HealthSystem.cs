using System.Collections;
using System.Collections.Generic;
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
        if (characterData.HP <= 0)
        {
            Destroy(gameObject);
        }
    }


    //Detect if damaged and apply damages is so
    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.gameObject.CompareTag("Weapon"))
        {
            WeaponData weaponData = collision.gameObject.GetComponent<WeaponData>();
            characterData.HP -= weaponData.DP;

            animator.SetTrigger("IsHurt");

            Debug.Log(collision.gameObject.name + "Hit");
        }
    }


}
