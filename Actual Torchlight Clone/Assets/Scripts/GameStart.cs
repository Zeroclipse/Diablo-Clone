using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameStart : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;
    private void Awake()
    {
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        temp.name = "Player";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.JoinLobby();
            PhotonNetwork.LoadLevel("Lobby");
        }
    }
}
