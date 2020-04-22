using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryFriend : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject prevPlayer;

    public float minFriction;
    public float maxFriction;
    private float currentFriction;

    private int cntPOnHead = 0;


    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        prevPlayer = gameManager.currentPlayer;

        //set friction its default value
        currentFriction = minFriction;
        gameObject.GetComponent<BoxCollider2D>().sharedMaterial.friction = currentFriction;
    }

    private void FixedUpdate()
    {
        ChangeFriction();
    }


    private void ChangeFriction()
    {
        //keep of changement of player
        if (prevPlayer != gameManager.currentPlayer)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        
        
            prevPlayer = gameManager.currentPlayer;;
        }

        //apply friction changement
        if (currentFriction != gameObject.GetComponent<BoxCollider2D>().friction)
        {
            //check if 2 player on head and if player carrying is the current player to avoid one of the two player on top to getting stuck
            if (cntPOnHead > 1 && gameObject.transform.parent.gameObject != gameManager.currentPlayer)
                gameObject.GetComponent<BoxCollider2D>().sharedMaterial.friction = minFriction;

            else
                gameObject.GetComponent<BoxCollider2D>().sharedMaterial.friction = currentFriction;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.position.y - collision.collider.bounds.extents.y > collision.otherCollider.transform.position.y + collision.otherCollider.bounds.extents.y)
        {
            ++cntPOnHead;

            if (collision.collider.gameObject != gameManager.currentPlayer)
            {
                currentFriction = maxFriction;
            }
            
            else
            {
                //reset
                currentFriction = minFriction;
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (cntPOnHead > 0) --cntPOnHead;

        //reset
        currentFriction = minFriction;
    }
}
