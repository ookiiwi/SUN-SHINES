using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform barSprite;
    private Quaternion rotation;

    private void Awake()
    {
        rotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = rotation;
    }

    public void Bar(float HP)
    {
        barSprite.localScale = new Vector3((HP / 100), 1f);     

        if (HP < ((100 / 3) * 2) && HP > (100 / 3))
        {
            barSprite.GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }

        else if(HP < (100 / 3))
        {
            barSprite.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }
}
