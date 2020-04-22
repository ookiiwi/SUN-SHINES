using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Dictionary<string, int>> inventory;
    public FireBallS_Obj firstFireBall;
    public PotionSO firstPotion;
    private void Start()
    {
        inventory = new List<Dictionary<string, int>>();
        AddItem(firstFireBall.m_name);
        AddItem(firstPotion.m_name);
    }

    public void AddItem(string itemName)
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].ContainsKey(itemName))
            {
                ++inventory[i][itemName];

                return;
            }
        }

        Dictionary<string, int> newItem = new Dictionary<string, int>();
        newItem.Add(itemName, 1);
        inventory.Add(newItem);
    }

    public void AddItem(string itemName, int itemQuantity)
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].ContainsKey(itemName))
            {
                inventory[i][itemName] = itemQuantity;

                return;
            }
        }

        Dictionary<string, int> newItem = new Dictionary<string, int>();
        newItem.Add(itemName, itemQuantity);
        inventory.Add(newItem);
    }

    public void RemoveItem(string itemName)
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].ContainsKey(itemName))
            {
                inventory.RemoveAt(i);
            }
        }
    }

    public bool HaveItem(string itemName)
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].ContainsKey(itemName))
            {
                return true;
            }
        }

        return false;
    }

    public int ItemQuantity(string itemName)
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            foreach (KeyValuePair<string, int> item in inventory[i])
            {
                if (inventory[i].ContainsKey(itemName))
                {
                    return item.Value;
                }
            }
        }

        return 0;
    }
}
