using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform barSprite;
    public CharacterData characterData;
    private Quaternion rotation;

    private float HP;
    private float prevHP;

    private void Awake()
    {
        rotation = transform.rotation;

        prevHP = characterData.MaxHP;
    }

    private void Update()
    {
        Bar();

        HP = characterData.HP;

        Debug.Log("prev HP: " + prevHP);
        Debug.Log("HP/100: " + (characterData.HP / 100));
    }

    private void LateUpdate()
    {
        transform.rotation = rotation;
    }

    public void Bar()
    {
        if (characterData.HP < prevHP)
        {
            prevHP = HP;
            Vector3 barLevel = new Vector3((HP / 100), barSprite.localScale.y).normalized;

            barSprite.localScale = new Vector3(barLevel.x, 1f);

            if (HP < (100 / 3 * 2) && HP > (100 / 3))
            {
                barSprite.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }

            else if (HP < (100 / 3))
            {
                barSprite.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
