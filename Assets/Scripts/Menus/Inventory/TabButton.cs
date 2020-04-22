using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public bool isItem;

    public TabManager tabManager;
    public Image bg;

    public ScriptableObject item;
    public Image itemImage;
    public Sprite padlock;

    private GameManager gameManager;
    private Inventory inventory;

    private void Start()
    {
        bg = GetComponent<Image>();
        tabManager.Subscribe(this);
    }

    private void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        inventory = gameManager.currentPlayer.GetComponent<Inventory>();

        if (isItem)
        {

            if (item is FireBallS_Obj)
            {
                if (inventory.HaveItem((item as FireBallS_Obj).m_name))
                {
                    FireBallS_Obj fb = item as FireBallS_Obj;
                    itemImage.sprite = fb.m_sprite;

                    itemImage.SetNativeSize();
                }

                else
                {
                    itemImage.sprite = padlock;

                    itemImage.SetNativeSize();
                }
            }

            else if (item is PotionSO)
            {
                if (inventory.HaveItem((item as PotionSO).m_name))
                {
                    PotionSO potion = item as PotionSO;
                    itemImage.sprite = potion.m_sprite;

                    itemImage.SetNativeSize();
                }

                else
                {
                    itemImage.sprite = padlock;

                    itemImage.SetNativeSize();
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabManager.OnTabSelected(this);

        if (isItem)
        {
            tabManager.OnTabSelected(item, inventory);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabManager.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabManager.OnTabExit(this);
    }
}
