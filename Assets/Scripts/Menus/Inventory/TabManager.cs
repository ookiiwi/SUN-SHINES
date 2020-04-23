using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    public GameManager gameManager;

    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> pages;
    public GameObject descriptionPage;

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

    public void OnTabEnter(TabButton button, ScriptableObject item, Inventory inventory)
    {
        OnTabEnter(button);

        if (item != null)
        {
            ShowDescription(button, item, inventory);
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

    public void OnTabSelected(TabButton button, ScriptableObject item, Inventory inventory)
    {
        OnTabSelected(button);

        if (item != null)
        {
            if (item is FireBallS_Obj)
            {
                if (inventory.HaveItem((item as FireBallS_Obj).m_name))
                {
                    gameManager.currentPlayer.GetComponent<CharacterData>().fireBallUsed = item as FireBallS_Obj;
                }
            }

            else if (item is PotionSO)
            {
                PotionSO potion = item as PotionSO;

                if (inventory.HaveItem(potion.m_name) && inventory.ItemQuantity(potion.m_name) > 0)
                {
                    gameManager.currentPlayer.GetComponent<CharacterData>().potionUsed = item as PotionSO;

                    inventory.AddItem(potion.m_name, inventory.ItemQuantity(potion.m_name) - 1);

                    selectedTab = null;
                }
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

            if (button.item != null)
            {
                descriptionPage.SetActive(false);
            }

        }
    }

    private void ShowDescription(TabButton button, ScriptableObject item, Inventory inventory)
    {
        if (item is FireBallS_Obj)
        {
            FireBallS_Obj fb = item as FireBallS_Obj;

            if (inventory.HaveItem(fb.m_name) && fb.m_description != null)
            {
                TextMeshProUGUI descriptionText = descriptionPage.GetComponentInChildren<TextMeshProUGUI>();
                descriptionText.SetText(fb.m_description.text + "\nDamages: " + fb.m_DP + "\nLife time: " + fb.m_lifeTime);

                float textPosX = descriptionPage.transform.position.x;
                float textPosY = descriptionPage.transform.position.y + descriptionPage.GetComponent<RectTransform>().sizeDelta.y / 2;
                float panelPosX = button.transform.position.x + descriptionPage.GetComponent<RectTransform>().sizeDelta.x / 2 + button.GetComponent<RectTransform>().sizeDelta.x;
                float panelPosY = button.transform.position.y - descriptionPage.GetComponent<RectTransform>().sizeDelta.y / 2;

                descriptionText.transform.position = new Vector3(textPosX, textPosY);
                descriptionPage.transform.position = new Vector3(panelPosX, panelPosY);
                descriptionPage.SetActive(true);
            }
        }

        else if (item is PotionSO)
        {
            PotionSO potion = item as PotionSO;

            if (inventory.HaveItem(potion.m_name) && potion.m_description != null)
            {
                descriptionPage.GetComponentInChildren<TextMeshProUGUI>().SetText(potion.m_description.text);
            }
        }
    }
}
