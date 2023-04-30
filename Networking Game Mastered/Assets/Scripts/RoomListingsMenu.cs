using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;
    [SerializeField] private RoomListing roomListing;
    [SerializeField] private List<RoomListing> listRoomListing = new List<RoomListing>();
    [SerializeField] private GameObject[] roomCanvases;

    public override void OnJoinedRoom()
    {
        roomCanvases[0].SetActive(false);
        roomCanvases[1].SetActive(true);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                var index = listRoomListing.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listRoomListing[index].gameObject);
                    listRoomListing.RemoveAt(index);
                }
            }
            else
            {
                var roomListingInstance = Instantiate(roomListing, content);
                if (roomListingInstance != null)
                {
                    listRoomListing.Add(roomListingInstance);
                    roomListingInstance.SetRoomInfo(info);
                }
            }
        }
    }
}
