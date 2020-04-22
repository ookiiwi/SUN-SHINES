using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestContent : MonoBehaviour
{
    public List<ScriptableObject> items;
    private GameObject item;
    private GameManager gameManager;

    public Sprite openedChest;

    private SpriteRenderer spriteRenderer;

    private bool empty = false;
    private bool openChest = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && openChest && !empty)
        {
            OpenChest();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        openChest = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openChest = false;
    }

    private void OpenChest()
    {
        empty = true;

        int randomItem = Random.Range(0, items.Count);
        Inventory playerInventory = gameManager.currentPlayer.GetComponent<Inventory>();


        item = new GameObject();
        item.AddComponent<SpriteRenderer>();
        item.GetComponent<SpriteRenderer>().sortingOrder = 0;


        spriteRenderer.sprite = openedChest;

        if (items[randomItem] is PotionSO)
        {
            PotionSO potion = items[randomItem] as PotionSO;
            playerInventory.AddItem(potion.m_name);

            item.GetComponent<SpriteRenderer>().sprite = potion.m_sprite;
            item.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        }

        GameObject inst = Instantiate(item, transform);
        DestroyItem(inst);

    }

    private IEnumerator DestroyItem(GameObject inst)
    {
        yield return new WaitForSeconds(1f);
        Destroy(inst);

        Debug.Log("Destroy");
    }
}
