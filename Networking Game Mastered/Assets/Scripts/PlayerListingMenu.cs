using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;
    [SerializeField] private PlayerListing playerListing;
    [SerializeField] private List<PlayerListing> listPlayerListing = new List<PlayerListing>();
    [SerializeField] private GameObject[] roomCanvases;
    [SerializeField] private GameManager GameManager;
    
    public void StartGame()
    {
        roomCanvases[1].SetActive(false);
        roomCanvases[0].SetActive(false);
        GameManager.StartGame();
    }
    
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    
    public override void OnLeftRoom()
    {
        roomCanvases[1].SetActive(false);
        roomCanvases[0].SetActive(true);
    }
    
    private void Awake()
    {
        GetCurrentRoomPlayers();
    }

    private void GetCurrentRoomPlayers()
    {
        foreach (var playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void AddPlayerListing(Player player)
    {
        var roomListingInstance = Instantiate(playerListing, content);
        if (roomListingInstance != null)
        {
            listPlayerListing.Add(roomListingInstance);
            roomListingInstance.SetPlayerInfo(player);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        var index = listPlayerListing.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(listPlayerListing[index].gameObject);
            listPlayerListing.RemoveAt(index);
        }
    }
}
