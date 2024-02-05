using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 2;
    int roomNumber = 1;

    [SerializeField] TextMeshProUGUI error;
    [SerializeField] TextMeshProUGUI loadingText;
    [SerializeField] GameObject lobby;

    public Controller controller;

    void Start()
    {
        print("Connecting to Server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to Master");
        //PhotonNetwork.JoinRoom($"New_Room_{roomNumber}");

        loadingText.gameObject.SetActive(false);
        lobby.SetActive(true);
    }

    public void Create_Room(TextMeshProUGUI roomName)
    {
        if(roomName.text == null)
        {
            error.text = "Enter a room name";
            return;
        }
        else
        {
            PhotonNetwork.CreateRoom(roomName.text, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }
        
    }
    
    public void Join_Room(TextMeshProUGUI roomName)
    {
        if(roomName.text == null)
        {
            error.text = "Enter a room name";
            return;
        }
        else
        {
            PhotonNetwork.JoinRoom(roomName.text);
        }
        
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        error.text = message;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        error.text = message;
    }

    public override void OnJoinedRoom()
    {
        print("Joined Room");
        StartCoroutine(controller.Loading());
    }
}
