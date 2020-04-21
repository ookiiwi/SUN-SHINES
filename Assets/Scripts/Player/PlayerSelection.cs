using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public List<GameObject> players;
    public Transform selectionArrow;
    public Vector3 offsetArrow;

    public Cinemachine.CinemachineVirtualCamera VM;

    private GameManager gameManager;

    private int playerSelected;

    private bool p_AIFollow;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerSelected = 0;
        OnSelection(players[playerSelected].transform);

        gameManager.currentPlayer = players[playerSelected];

        AjustIndex();
    }

    private void Update()
    {
        AjustIndex();

        CurrentSelection();

        foreach (GameObject player in players)
        {
            PlayerAI playerAI = player.GetComponent<PlayerAI>();

            if (player != gameManager.currentPlayer)
            {
                if (!playerAI.follow)
                {
                    p_AIFollow = false;

                    break;
                }

                else if (playerAI.follow)
                {
                    p_AIFollow = true;
                }
            }
        }

        foreach (GameObject player in players)
        {
            PlayerAI playerAI = player.GetComponent<PlayerAI>();

            if (player != players[playerSelected])
            {
                playerAI.followlow = p_AIFollow;
            }
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
            players.Remove(players[playerSelected]);

            if (playerSelected >= players.Count - 1)
                --playerSelected;

            else if (playerSelected <= 0)
                ++playerSelected;

            else if (players.Count - 1 == 0)
            {
                playerSelected = 0;
            }

            else
                --playerSelected;

            Debug.Log("remove player");
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

        gameManager.currentPlayer = players[playerSelected];
    }

    private void AjustIndex()
    {
        if (players.Count > 0)
        {
            for (int i = 0; i < players.Count - 1; ++i)
            {
                if (players[i].transform.position.x < players[i + 1].transform.position.x)
                {
                    GameObject tmp = players[i];
                    players[i] = players[i + 1];
                    players[i + 1] = tmp;

                    if (players[i] == gameManager.currentPlayer) playerSelected = i;

                    else if (players[i + 1] == gameManager.currentPlayer) playerSelected = i + 1;
                }
            }
        }

        for (int i = 0; i < players.Count; ++i)
        {
            Debug.Log(i + ": " + players[i]);
        }
    }
}
