using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        Debug.Log("Connecting to server...");
        PhotonNetwork.GameVersion = "0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnConnectedToServer()
    {
        Debug.Log("Connected to the server!");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server! Error:" + cause);
    }
}
