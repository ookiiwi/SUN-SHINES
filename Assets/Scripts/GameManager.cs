using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject inventory;

    [HideInInspector] public GameObject currentPlayer;

    public bool isInputEnabled = true;

    private GameObject openedMenu;


    private void Awake()
    {
        MakeSingleton();
    }

    private void Update()
    {
        //open and close inventory
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (openedMenu == null)
            {
                Time.timeScale = 0f;
                isInputEnabled = false;

                openedMenu = inventory;
                inventory.SetActive(true);
            }

            else
            {
                Time.timeScale = 1f;
                isInputEnabled = true;

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
