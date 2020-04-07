﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Transform firePoint;
    public GameObject fireBall;
    

    private void Awake()
    {
        firePoint = GameObject.FindGameObjectWithTag("Fire Point").GetComponent<Transform>();
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(fireBall, new Vector2(firePoint.position.x, firePoint.position.y), firePoint.rotation);
    }
}
