using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PunLauncher : MonoBehaviourPunCallbacks
{
    public string gameVersion = "1";
    public byte maxPlayers = 3;
    Text status;
    string roomName = "default";
    RoomOptions roomOps;

    private void Start()
    {
        status = GameObject.Find("TxtConnection").GetComponent<Text>();
        roomOps = new RoomOptions();
        roomOps.MaxPlayers = maxPlayers;
        //Connect();
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("PlayerName");
            InputField playerInput = GameObject.Find("InputPlayerName").GetComponent<InputField>();
            playerInput.text = PlayerPrefs.GetString("PlayerName");
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Dropdown dropRoomList = GameObject.Find("DropRoomList").GetComponent<Dropdown>();
        dropRoomList.ClearOptions();
        List<Dropdown.OptionData> opData = new List<Dropdown.OptionData>();

        if (roomList.Count == 0)
        {
            opData.Add(new Dropdown.OptionData("NO ROOMS"));
        }
        else
        {
            foreach (RoomInfo ri in roomList)
            {
                opData.Add(new Dropdown.OptionData(ri.Name));
            }
        }
        dropRoomList.AddOptions(opData);
        dropRoomList.value = 0;
    }

    public void SetPlayerName()
    {
        InputField playerInput = GameObject.Find("InputPlayerName").GetComponent<InputField>();
        string tempPlayerName = playerInput.text;

        if (string.IsNullOrEmpty(tempPlayerName))
        {
            //status.text += ("Player name is empty");
            tempPlayerName = "Zeroclipse";
            PhotonNetwork.NickName = tempPlayerName;
            PlayerPrefs.SetString("PlayerName", tempPlayerName);
        }
        else
        {
            PhotonNetwork.NickName = tempPlayerName;
            PlayerPrefs.SetString("PlayerName", tempPlayerName);
        }
    }
    public void SetRoomName()
    {
        InputField playerInput = GameObject.Find("InputRoomName").GetComponent<InputField>();
        string tempRoomName = playerInput.text;

        if (string.IsNullOrEmpty(tempRoomName))
        {
            status.text += ("Room name is empty");
        }
        else
        {
            roomName = tempRoomName;
            PhotonNetwork.JoinOrCreateRoom(roomName, roomOps, null);
        }
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            status.text += ("\nAlready Connected");
            //PhotonNetwork.JoinRandomRoom();
            //PhotonNetwork.JoinOrCreateRoom(roomName, roomOps, null);
            if (!PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinLobby();
            }
        }

        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        status.text += ("\n<color=green>Connected to server</color>");
        //PhotonNetwork.JoinRandomRoom();
        //PhotonNetwork.JoinOrCreateRoom(roomName, roomOps, null);
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        status.text += ("\n<color=red>Disconnected from server </color> : " + cause.ToString());
    }

    //public override void OnJoinRandomFailed(short returnCode, string message)
    //{
    //    status.text += ("\n<color=red>Failed to join</color>: " + message);
    //    //print(message);
    //    //RoomOptions roomsOps = new RoomOptions();
    //    //roomsOps.MaxPlayers = maxPlayers;
    //    //roomsOps.PlayerTtl = 10;
    //    //roomsOps.EmptyRoomTtl = 10;
    //    //PhotonNetwork.CreateRoom(null, roomOps);
    //}

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        status.text += ("\n<color=red>Failed to join</color>: " + message);
    }

    public override void OnJoinedRoom()
    {
        status.text += ("\n<color=green>Joined Room</color>");
        PhotonNetwork.LoadLevel("Level One");
    }
}
