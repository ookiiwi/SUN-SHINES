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

    private void Awake()
    {
        if (isItem)
        {
            if (item is FireBallS_Obj)
            {
                FireBallS_Obj fb = item as FireBallS_Obj;
                itemImage.sprite = fb.m_sprite;

                itemImage.SetNativeSize();

                Debug.Log("Set fireball sprite");
            }

            else if (item is PotionSO)
            {
                PotionSO potion = item as PotionSO;
                itemImage.sprite = potion.m_sprite;

                itemImage.SetNativeSize();

                Debug.Log("Set potion sprite");
            }
        }
    }

    private void Start()
    {
        bg = GetComponent<Image>();
        tabManager.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        tabManager.OnTabSelected(this);

        if (isItem)
        {
            tabManager.OnTabSelected(item);
        }

        Debug.Log("Clicked");
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
