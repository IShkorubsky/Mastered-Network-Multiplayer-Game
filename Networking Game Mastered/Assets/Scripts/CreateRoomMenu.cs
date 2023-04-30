using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text roomName;

    public void CreateRoomButton()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room Successfully!");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to Create Room...");
    }
}
