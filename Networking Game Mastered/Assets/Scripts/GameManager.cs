using System.IO;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    private PhotonView PV;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] playerSpawnPositions;

    public void StartGame()
    {
        PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, playerSpawnPositions.Length);
        if (PV.IsMine)
        {
            var myAvatar = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player"),
                playerSpawnPositions[spawnPicker].position, playerSpawnPositions[spawnPicker].rotation);
        }
    }
}