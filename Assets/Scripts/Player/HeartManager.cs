using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public List<GameObject> hearts;
    public Sprite[] heartSprites;
    public GameManager gameManager;

    private CharacterData playerData;

    private int currentHeart;

    private void Start()
    {
        playerData = gameManager.currentPlayer.GetComponent<CharacterData>();

        currentHeart = hearts.Count - 1;

        CheckSelection();
    }

    private void Update()
    {
        if (gameManager.currentPlayer != null)
            playerData = gameManager.currentPlayer.GetComponent<CharacterData>();

        CheckSelection();

        Damage();
    }

    private void Damage()
    {
        if (currentHeart < 0)
         return;

        if (playerData.HP < playerData.prevHP)
        {
            hearts[currentHeart].GetComponent<SpriteRenderer>().sprite = heartSprites[playerData.HP];

            playerData.prevHP = playerData.HP;
        }

        if (playerData.HP < 1)
        {
            playerData.HP = playerData.MaxHP;
            playerData.prevHP = playerData.HP;
            ++playerData.emptyHearts;
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

    private void CheckSelection()
    {
        int p_hearts = playerData.hearts;
        int p_emptyHearts = playerData.emptyHearts;
        int p_HP = playerData.HP;


        if (gameManager.currentPlayer != null)
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
                currentHeart = p_hearts - p_emptyHearts - 1;
                hearts[currentHeart].GetComponent<SpriteRenderer>().sprite = heartSprites[p_HP];

                if (p_emptyHearts > 0)
                {
                    for (int i = p_hearts - p_emptyHearts; i < p_hearts; ++i)
                    {
                        hearts[i].GetComponent<SpriteRenderer>().sprite = heartSprites[0];
                    }
                }
            }
        }
    }
}
