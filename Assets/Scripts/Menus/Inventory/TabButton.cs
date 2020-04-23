using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public bool isItem;

    public TabManager tabManager;
    public Image bg;

    public ScriptableObject item;
    public Image itemImage;
    public Sprite padlock;
    public bool unlocked = false;
    public GameObject counter;

    private GameManager gameManager;
    private Inventory inventory;

    private void Start()
    {
        bg = GetComponent<Image>();
        tabManager.Subscribe(this);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        inventory = gameManager.currentPlayer.GetComponent<Inventory>();

        if (isItem)
        {
            CheckItem(item);
        }
    }

    private void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        inventory = gameManager.currentPlayer.GetComponent<Inventory>();

        if (isItem)
        {
            CheckItem(item);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isItem && unlocked)
        {
            tabManager.OnTabSelected(this, item, inventory);
        }

        else if (unlocked)
        {
            tabManager.OnTabSelected(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isItem && unlocked)
        {
            tabManager.OnTabEnter(this, item, inventory);
        }

        else if (unlocked)
        {
            tabManager.OnTabEnter(this);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabManager.OnTabExit(this);
    }

    private void CheckItem(ScriptableObject item)
    {
        if (item is FireBallS_Obj)
        {
            if (inventory.HaveItem((item as FireBallS_Obj).m_name))
            {
                unlocked = true;

                FireBallS_Obj fb = item as FireBallS_Obj;
                itemImage.sprite = fb.m_sprite;
                itemImage.transform.localScale = new Vector3(0.36f, 0.36f);
                itemImage.SetNativeSize();
            }

            else
            {
                unlocked = false;

                itemImage.sprite = padlock;
                itemImage.transform.localScale = new Vector3(0.6f, 0.6f);
                itemImage.SetNativeSize();
            }
        }

        else if (item is PotionSO)
        {
            if (inventory.HaveItem((item as PotionSO).m_name))
            {
                unlocked = true;

                PotionSO potion = item as PotionSO;
                itemImage.sprite = potion.m_sprite;

                itemImage.transform.localScale = new Vector3(0.6f, 0.6f);
                itemImage.SetNativeSize();

                if (gameObject.GetComponentInChildren<TextMeshProUGUI>() == null)
                {
                    GameObject cntInst = Instantiate(counter);
                    cntInst.transform.parent = transform;
                    cntInst.transform.localPosition = counter.GetComponent<RectTransform>().localPosition;
                    cntInst.GetComponent<TextMeshProUGUI>().SetText(inventory.ItemQuantity(potion.m_name).ToString());
                }

                else
                {
                    gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(inventory.ItemQuantity(potion.m_name).ToString());
                }
            }

            else
            {
                unlocked = false;

                itemImage.sprite = padlock;
                itemImage.transform.localScale = new Vector3(0.6f, 0.6f);
                itemImage.SetNativeSize();
            }
        }
    }
}
