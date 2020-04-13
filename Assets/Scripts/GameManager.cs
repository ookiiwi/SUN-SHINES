using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> players;
    public Transform selectionArrow;
    public Vector3 offsetArrow;

    public Cinemachine.CinemachineVirtualCamera VM;

    private int playerSelected;
    [HideInInspector] public GameObject currentPlayer;


    private void Awake()
    {
        MakeSingleton();

        playerSelected = 0;
        OnSelection(players[playerSelected].transform);

        currentPlayer = players[playerSelected];
    }

    private void Update()
    {
        CurrentSelection();
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

    private void OnSelection(Transform player)
    {
        selectionArrow.position = player.position + offsetArrow;
    }

    private void CurrentSelection()
    {
        if (players[playerSelected] == null)
        {
            players.RemoveAt(playerSelected);

            if (playerSelected >= players.Count - 1)
                --playerSelected;

            else if (playerSelected <= 0)
                ++playerSelected;

            else
                --playerSelected;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            players[playerSelected].GetComponent<PlayerManager>().isAI = true;

            if (playerSelected <= 0)
            {
                playerSelected = players.Count - 1;
            }

            else
            {
                --playerSelected;
            }


            players[playerSelected].GetComponent<PlayerManager>().isAI = false;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            players[playerSelected].GetComponent<PlayerManager>().isAI = true;

            if (playerSelected >= players.Count - 1)
            {
                playerSelected = 0;
            }

            else
            {
                ++playerSelected;
            }

            players[playerSelected].GetComponent<PlayerManager>().isAI = false;
        }

        OnSelection(players[playerSelected].transform);

        VM.Follow = players[playerSelected].transform;

        currentPlayer = players[playerSelected];
    }
}
