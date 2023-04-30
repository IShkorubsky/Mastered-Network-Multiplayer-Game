using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerListing : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    public Player Player { get; private set; }
    
    public void SetPlayerInfo(Player player)
    {
        Player = player;
        playerName.text = $"{player.NickName}";
    }
}
