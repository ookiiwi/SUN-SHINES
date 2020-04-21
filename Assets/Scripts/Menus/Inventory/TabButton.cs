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

    public void OnPointerClick(PointerEventData eventData)
    {
        tabManager.OnTabSelected(this);

        if (isItem)
        {
            tabManager.OnTabSelected(item);
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
