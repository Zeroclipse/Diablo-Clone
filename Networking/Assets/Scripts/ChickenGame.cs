using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChickenGame : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    private void Start()
    {
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        temp.name = "ChickenPlayer";
    }
}
