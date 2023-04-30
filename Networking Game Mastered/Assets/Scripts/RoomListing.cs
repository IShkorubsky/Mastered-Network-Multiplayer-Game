using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomListing : MonoBehaviour
{
    [SerializeField] private TMP_Text roomName;
    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        roomName.text = $"Players: {roomInfo.PlayerCount}|{roomInfo.MaxPlayers} - {roomInfo.Name}";
    }

    public void JoinRoomButton()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
