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
            float normalizedHP = HP / characterData.MaxHP;

            barSprite.localScale = new Vector3(normalizedHP, 1f);
        }
    }
}
