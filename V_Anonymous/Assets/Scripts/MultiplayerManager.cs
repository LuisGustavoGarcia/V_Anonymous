using System.Collections;
using System.Collections.Generic;
using Photon;
using UnityEngine.UI;
using UnityEngine;

public class MultiplayerManager : PunBehaviour
{

    public string versionName = "0.1";
    public GameObject lobbyView1, lobbyView2, lobbyView3;
    public InputField createRoomInput, joinRoomInput;
    public RoomManager roomManager;
    public GameObject roomsList;
    public ButtonListControl rooms;
    public byte maxPlayers = 6;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Connecting to photon");
        lobbyView1.SetActive(true);
        lobbyView2.SetActive(false);
        lobbyView3.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("We are connected to Master");
    }

    public override void OnDisconnectedFromPhoton()
    {
        lobbyView1.SetActive(false);
        lobbyView2.SetActive(false);
        lobbyView3.SetActive(true);
        roomsList.SetActive(false);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        lobbyView1.SetActive(false);
        lobbyView2.SetActive(true);
        lobbyView3.SetActive(false);
        roomsList.SetActive(true);
    }

    public void OnClickJoinRoom()
    {
        Debug.Log(joinRoomInput.text);
        this.JoinOrCreateRoom(joinRoomInput.text);
    }

    public void OnClickCreateRoom()
    {
        if(createRoomInput.text.Length > 0)
        {
            Debug.Log("Creating a room");
            this.CreateNewRoom(createRoomInput.text);
        }
    }

    public void CreateNewRoom(string roomName)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.CreateRoom(roomName, roomOptions, null);
    }

    public void JoinOrCreateRoom(string roomName)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, null);
    }

    public override void OnReceivedRoomListUpdate()
    {
        rooms.rooms = PhotonNetwork.GetRoomList();
        if (rooms.rooms.Length > 0)
        {
            roomsList.SetActive(true);
            rooms.UpdateList();
        }
        else
        {
            roomsList.SetActive(false);
        }
    }



}
