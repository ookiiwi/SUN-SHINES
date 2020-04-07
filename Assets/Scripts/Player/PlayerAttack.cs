using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireBall;

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(fireBall, firePoint.position, firePoint.rotation);
    }
}
