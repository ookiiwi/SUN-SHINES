using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    public GameManager gameManager;

    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> pages;

    public  void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();

        if (selectedTab == null || button != selectedTab)
        {
            button.bg.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;

        ResetTabs();
        button.bg.sprite = tabActive;

        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < pages.Count; ++i)
        {
            if (i == index)
            {
                pages[i].SetActive(true);
            }

            else
            {
                pages[i].SetActive(false);
            }
        }
    }

    public void OnTabSelected(ScriptableObject item)
    {
        if (item != null)
        {
            if (item is FireBallS_Obj)
            {
                gameManager.currentPlayer.GetComponent<CharacterData>().fireBallUsed = item as FireBallS_Obj;
            }

            else if (item is PotionSO)
            {
                gameManager.currentPlayer.GetComponent<CharacterData>().potionUsed = item as PotionSO;
            }

            else
            {
                Debug.Log("Wrong type");
            }
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if (selectedTab != null && selectedTab == button) continue;

            button.bg.sprite = tabIdle;
        }
    }
}
