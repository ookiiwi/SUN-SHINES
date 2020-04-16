using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public List<GameObject> hearts;
    public Sprite[] heartSprites;
    public GameManager gameManager;

    private CharacterData playerData;
    private GameObject prevPlayer;

    private int currentHeart;
    private int heartStates;
    private int currentHeartState;
    private int prevHP;

    private void Start()
    {
        playerData = gameManager.currentPlayer.GetComponent<CharacterData>();
        prevPlayer = null;

        currentHeart = hearts.Count - 1;
        heartStates = heartSprites.Length - 1;
        currentHeartState = heartStates;

        prevHP = playerData.MaxHP;

        CheckNewSelected();
    }

    private void Update()
    {
        if (gameManager.currentPlayer != null)
            playerData = gameManager.currentPlayer.GetComponent<CharacterData>();

        CheckNewSelected();

        Damage();
    }

    private void Damage()
    {
        if (playerData.HP < playerData.prevHP)
        {
            hearts[currentHeart].GetComponent<SpriteRenderer>().sprite = heartSprites[--currentHeartState];

            playerData.prevHP = playerData.HP;
        }

        if (currentHeartState < 1)
        {
            playerData.HP = playerData.MaxHP;
            playerData.prevHP = playerData.HP;
            ++playerData.emptyHearts;

            currentHeartState = heartStates;
            --currentHeart;
        }
    }

    private void AddHeart()
    {
        GameObject newHeart = Instantiate(hearts[hearts.Count - 1].gameObject);
        newHeart.transform.parent = gameObject.transform;
        newHeart.transform.localScale /= 2;
        newHeart.gameObject.transform.position = new Vector3(hearts[hearts.Count - 1].transform.position.x + 0.5f, hearts[hearts.Count - 1].transform.position.y);

        hearts.Add(newHeart);
    }

    private void CheckNewSelected()
    {
        int p_hearts = playerData.hearts;
        int p_emptyHearts = playerData.emptyHearts;
        int p_HP = playerData.HP;


        if (prevPlayer != gameManager.currentPlayer && gameManager.currentPlayer != null)
        {
            if (p_emptyHearts < p_hearts)
            {
                // check if add hearts
                if (hearts.Count < p_hearts)
                {
                    for (int i = hearts.Count; i < p_hearts; ++i)
                    {
                        AddHeart();
                    }
                }

                // remove hearts
                else if (hearts.Count > p_hearts)
                { 
                    for (int i = hearts.Count - 1; i + 1 > p_hearts;  --i)
                    {
                        Destroy(hearts[i]);
                        hearts.RemoveAt(i);
                    }
                }


                //fill every plain hearts except the last one
                for (int i = 0; i < p_hearts - p_emptyHearts - 1; ++i)
                {
                    hearts[i].GetComponent<SpriteRenderer>().sprite = heartSprites[heartSprites.Length - 1];
                }

                //set the right sprite for the last non empty heart
                currentHeartState = p_HP / 100;
                currentHeart = p_hearts - p_emptyHearts - 1;
                hearts[currentHeart].GetComponent<SpriteRenderer>().sprite = heartSprites[currentHeartState];

                if (p_emptyHearts > 0)
                {
                    for (int i = p_hearts - p_emptyHearts; i < p_hearts; ++i)
                    {
                        hearts[i].GetComponent<SpriteRenderer>().sprite = heartSprites[0];
                    }
                }
            }

            

            prevPlayer = gameManager.currentPlayer;
        }
    }
}
