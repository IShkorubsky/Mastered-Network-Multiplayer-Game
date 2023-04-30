using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text gameVersionText;
    [SerializeField] private TMP_Text playerNameText;

    [SerializeField] private GameObject[] roomCanvases;

    private void Start()
    {
        Debug.Log("Connecting to server...");
        PhotonNetwork.GameVersion = "0.1";
        var randomNumber = Random.Range(0, 100);
        PhotonNetwork.LocalPlayer.NickName = $"Player{randomNumber.ToString()}";
        PhotonNetwork.ConnectUsingSettings();
        playerNameText.text = PhotonNetwork.LocalPlayer.NickName;
        playerNameText.gameObject.SetActive(true);
        gameVersionText.text = $"v {PhotonNetwork.GameVersion}";
        gameVersionText.gameObject.SetActive(true);
        roomCanvases[0].SetActive(true);
        roomCanvases[1].SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to the server!");

        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server! Error:" + cause);
    }
}
