using System.IO;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    private PhotonView PV;
    [SerializeField] private GameObject playerPrefab;
    private Player[] allPlayers;
    private int myNumberInTheRoom;
    [SerializeField] private Transform[] playerSpawnPositions;

    public void StartGame()
    {
        PV = GetComponent<PhotonView>();
        allPlayers = PhotonNetwork.PlayerList;
        foreach (var player in allPlayers)
        {
            if (player != PhotonNetwork.LocalPlayer)
            {
                myNumberInTheRoom++;
            }
        }
        int spawnPicker = Random.Range(0, playerSpawnPositions.Length);
        if (PV.IsMine)
        {
            var myAvatar = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"),
                playerSpawnPositions[spawnPicker].position, playerSpawnPositions[spawnPicker].rotation);
        }
    }
}