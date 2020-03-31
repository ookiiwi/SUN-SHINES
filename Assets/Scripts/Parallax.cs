using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxHorizontal;
    [SerializeField] private GameObject cam;
    private float startPos, spriteLenght;

    private void Start()
    {
        startPos = transform.position.x;
        spriteLenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        //float temp = (cam.transform.position.x * (1 - parallaxHorizontal));
        float dist = cam.transform.position.x * parallaxHorizontal;
        
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        //if (temp > startPos + spriteLenght)
        //{
        //    startPos += spriteLenght;
        //}
        //
        //else if (temp < startPos - spriteLenght)
        //{
        //    startPos -= spriteLenght;
        //}

    }

}
