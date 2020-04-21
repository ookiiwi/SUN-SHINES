using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject inventory;

    [HideInInspector] public GameObject currentPlayer;

    private GameObject openedMenu;


    private void Awake()
    {
        MakeSingleton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (openedMenu == null)
            {
                openedMenu = inventory;
                inventory.SetActive(true);
            }

            else
            {
                openedMenu = null;
                inventory.SetActive(false);
            }
        }
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
}
