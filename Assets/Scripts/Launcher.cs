using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{
    [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
    [SerializeField]
    private byte maxPlayersPerRoom = 2;
    int roomNumber = 1;

    public Controller controller;

    void Start()
    {
        print("Connecting to Server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to Master");
        PhotonNetwork.JoinRoom($"New_Room_{roomNumber}");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Creating new room for 2 players");
        PhotonNetwork.CreateRoom($"New_Room_{roomNumber++}", new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        print("Joined Room");
        StartCoroutine(controller.Loading());
    }
}
