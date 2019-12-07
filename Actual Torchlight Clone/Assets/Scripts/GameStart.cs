using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.AI;

public class GameStart : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] GameObject playerPrefab;
    public Vector3 playerPosition;
    NavMeshSurface surface;
    public bool ready = false;
    private void Awake()
    {
        surface = GameObject.FindGameObjectWithTag("Ground").GetComponent<NavMeshSurface>();
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
        StartCoroutine(Ready());
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

    public void SetUp()
    {
        surface.BuildNavMesh();
        Debug.Log(surface.name);
        Debug.Log("Where's the NavMesh?");
        playerPosition = (Vector3)PhotonNetwork.CurrentRoom.CustomProperties["Players"];
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, playerPosition, Quaternion.identity);
        temp.name = "Player";
        ready = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
    public IEnumerator Ready()
    {
        while (PhotonNetwork.CurrentRoom.CustomProperties["Dungeon Generated"] == null)
        {
            yield return null;
        }
        while ((bool)PhotonNetwork.CurrentRoom.CustomProperties["Dungeon Generated"] == false)
        {
            yield return null;
        }
        SetUp();
    }
}
