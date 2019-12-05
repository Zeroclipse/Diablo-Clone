using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.AI;

public class GameStart : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;
    Vector3 playerPosition;
    NavMeshSurface surface;
    private void Awake()
    {
        GameObject.Find("Main Camera").GetComponent<LoadingScreen>().Load();
        if (PhotonNetwork.IsMasterClient)
        {
            GetComponent<Visualizer>().GenerateNewMap();
            GetComponent<GenerateDetails>().Details();
        }
    }

    private void Start()
    {
        GameObject.Find("Main Camera").GetComponent<LoadingScreen>().Stop();
        GameObject.FindGameObjectWithTag("Ground").GetComponent<NavMeshSurface>().BuildNavMesh();
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, playerPosition, Quaternion.identity);
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

    public void SetUp(Vector3 pos)
    {
        Debug.Log("Position");
        playerPosition = pos;
    }
}
