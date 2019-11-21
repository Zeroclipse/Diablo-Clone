using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameStart : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    private void Awake()
    {
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        temp.name = "Player";
    }
}
