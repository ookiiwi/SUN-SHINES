using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxHorizontal;
    [SerializeField] private GameObject cam;
    private float startPos;

    private void Start()
    {
        startPos = transform.position.x;
    }

    private void FixedUpdate()
    {
        float dist = cam.transform.position.x * parallaxHorizontal;

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

    }

}
