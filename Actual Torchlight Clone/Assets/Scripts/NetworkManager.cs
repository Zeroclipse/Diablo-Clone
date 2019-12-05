using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public string gameVersion = "1";
    public byte maxPlayers;
    string roomName = "default";
    RoomOptions roomOps;
    Text status;
    List<RoomInfo> list;
    bool host = false;
    bool joinable = false;
    private void Awake()
    {
        status = GameObject.Find("ErrorT").GetComponent<Text>();
        roomOps = new RoomOptions();
        GameObject.Find("SoloQ").GetComponent<Text>().text = "Solo Play";
        GameObject.Find("TSolo").GetComponent<Toggle>().isOn = false;
        GameObject.Find("ConnectText").GetComponent<Text>().text = "Connect";
        GameObject.Find("NameS").GetComponent<Text>().text = "Name";
    }

    private void Start()
    {
        if (PhotonNetwork.IsConnected == false)
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        status.text += ("\n<color=green>Connected to Server</color>");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        status.text += ("\n<color=green>Joined Lobby</color>");
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            status.text += ("\n<color=green>Your name is currently: " + PlayerPrefs.GetString("PlayerName") + "</color>");
            PhotonNetwork.NickName = PlayerPrefs.GetString("PlayerName");
            InputField playerInput = GameObject.Find("Nickname").GetComponent<InputField>();
            playerInput.text = PlayerPrefs.GetString("PlayerName");
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        list = roomList;
        Dropdown rooms = GameObject.Find("RoomListDrop").GetComponent<Dropdown>();
        rooms.ClearOptions();
        List<Dropdown.OptionData> data = new List<Dropdown.OptionData>();

        if (roomList.Count == 0)
        {
            data.Add(new Dropdown.OptionData("No Rooms Found."));
        }

        else
        {
            foreach (RoomInfo room in roomList)
            {
                data.Add(new Dropdown.OptionData(room.Name));
            }
        }

        rooms.AddOptions(data);
        rooms.value = 0;
    }

    public void SelectNickname()
    {
        InputField playerInput = GameObject.Find("Nickname").GetComponent<InputField>();
        string tempPlayerName = playerInput.text;

        if (string.IsNullOrEmpty(tempPlayerName))
        {
            status.text += ("\n<color=red>No Nickname entered!</color>");
        }
        else
        {
            PhotonNetwork.NickName = tempPlayerName;
            PlayerPrefs.SetString("PlayerName", tempPlayerName);
            status.text += ("\n<color=green>Your name is now: " + PlayerPrefs.GetString("PlayerName") + "</color>");
        }
    }

    public void Connect()
    {
        roomName = GameObject.Find("RoomName").GetComponent<InputField>().text;
        string soloName = "Solo Room ";
        Toggle solo = GameObject.Find("TSolo").GetComponent<Toggle>();
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            if (solo.isOn == true)
            {
                bool taken = false;
                maxPlayers = 1;
                foreach (RoomInfo data in list)
                {
                    if (data.Name == roomName)
                    {
                        taken = true;
                    }
                }

                if (taken == true || roomName == null)
                {
                    taken = false;
                    int i = 1;
                    bool naming = true;
                    while (naming)
                    {
                        roomName = soloName + i;
                        foreach (RoomInfo data in list)
                        {
                            if (data.Name == roomName)
                            {
                                taken = true;
                            }
                        }
                        if (taken == false)
                        {
                            naming = false;
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                maxPlayers = 4;
            }
            roomOps.MaxPlayers = maxPlayers;

            PhotonNetwork.JoinOrCreateRoom(roomName, roomOps, null);
        }
        else
        {
            status.text += ("\n<color=red>Sorry, You need to set a Name first</color>");
        }
    }

    public override void OnJoinedRoom()
    {
        //if (host == true)
        //{
        status.text += ("\n<color=green>You have Joined the room named " + roomName + "</color>");
        PhotonNetwork.LoadLevel("Level One");
        //}

        //else if (host == false && joinable == true)
        //{
        //status.text += ("\n<color=green>You have Joined the room named " + roomName + "</color>");
        //PhotonNetwork.LoadLevel("Test Room");
        //}
        //else
        //{

        //}
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        status.text += ("\n<color=red>Sorry, " + roomName + " is full</color>");
    }
    public override void OnCreatedRoom()
    {
        //status.text += ("\n<color=green>You have created the room named " + roomName + "</color>");
        //PhotonNetwork.LoadLevel("Level One");
        //host = true;
        //StartCoroutine(Timer());
    }

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(3f);
    //    joinable = true;
    //}
}
