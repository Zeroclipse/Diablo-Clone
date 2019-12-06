using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.AI;

public class GameStart : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] GameObject playerPrefab;
    Vector3 playerPosition;
    NavMeshSurface surface;
    public bool ready = false;
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
        //Debug.Log("Making Player");
        //Debug.Log(temp.name);
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
        if (PhotonNetwork.IsMasterClient)
        {
            playerPosition = pos;
        }
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, playerPosition, Quaternion.identity);
        temp.name = "Player";
        ready = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            stream.SendNext(playerPosition);
        }
        else
        {
            this.playerPosition = (Vector3)stream.ReceiveNext();
        }
    }
}
