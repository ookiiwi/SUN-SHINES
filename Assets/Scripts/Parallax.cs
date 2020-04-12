using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parallax : MonoBehaviour
{
    public Vector2 parallaxFX;

    private Transform cam;
    private Vector3 lastCamPos;
    private float texturePerUnitSizeX;
    

    private void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        texturePerUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void FixedUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxFX.x, deltaMovement.y * parallaxFX.y);
        lastCamPos = cam.position;

        if (Mathf.Abs(cam.position.x - transform.position.x) >= texturePerUnitSizeX)
        {
            float offsetPostionX = (cam.position.x - transform.position.x) % texturePerUnitSizeX;
            transform.position = new Vector3(cam.position.x + offsetPostionX, transform.position.y);
        }
    }
}
