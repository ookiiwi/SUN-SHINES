using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestContent : MonoBehaviour
{
    public List<ScriptableObject> items;
    private GameObject item;
    private GameObject itemInst;
    private GameManager gameManager;
    private Animator animator;

    private bool empty = false;
    private bool openChest = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>(); 
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
        animator.enabled = true;
        StartCoroutine(DoPop());
    }

    private IEnumerator DoPop()
    {
        int randomItem = Random.Range(0, items.Count);
        Inventory playerInventory = gameManager.currentPlayer.GetComponent<Inventory>();


        item = new GameObject();
        item.AddComponent<SpriteRenderer>();
        item.GetComponent<SpriteRenderer>().sortingOrder = 0;

        if (items[randomItem] is PotionSO)
        {
            PotionSO potion = items[randomItem] as PotionSO;
            playerInventory.AddItem(potion.m_name);

            item.GetComponent<SpriteRenderer>().sprite = potion.m_sprite;
            item.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        }

        yield return new WaitForSeconds(0.6f);

        itemInst = Instantiate(item, transform);
        StartCoroutine(DestroyItem());
    }

    private IEnumerator DestroyItem()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(itemInst);

        Debug.Log("Destroy");
    }
}
