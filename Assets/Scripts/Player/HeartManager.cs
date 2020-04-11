using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public List<GameObject> hearts;
    public Sprite[] heartSprites;
    //public GameObject player;
    public CharacterData playerData;

    private int currentHeart;
    private int heartStates;
    private int currentHeartState;
    private int prevHP;

    private void Start()
    {
        //playerHealth = player.GetComponent<CharacterData>();

        currentHeart = hearts.Count - 1;
        heartStates = heartSprites.Length - 1;
        currentHeartState = heartStates;

        prevHP = playerData.MaxHP;

        //AddHeart();
    }

    private void Update()
    {
        Damage();
    }

    private void Damage()
    {
        if (playerData.HP < prevHP)
        {
            if (currentHeartState <= 0)
            {
                playerData.HP = playerData.MaxHP;
                
                --currentHeart;
                currentHeartState = heartStates;
            }

            if (currentHeartState <= 1)
            {
                ++playerData.emptyHearts;
            }

            hearts[currentHeart].GetComponent<SpriteRenderer>().sprite = heartSprites[--currentHeartState];

            prevHP = playerData.HP;
        }
    }

    private void AddHeart()
    {
        GameObject newHeart = Instantiate(hearts[hearts.Count - 1].gameObject);
        newHeart.transform.parent = gameObject.transform;
        newHeart.transform.localScale /= 2;
        newHeart.gameObject.transform.position = new Vector3(hearts[hearts.Count - 1].transform.position.x + 0.5f, hearts[hearts.Count - 1].transform.position.y);

        hearts.Add(newHeart);

        ++currentHeart;
        ++playerData.hearts;
        --playerData.emptyHearts;
    }
}
