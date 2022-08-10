using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System.Net;
using TMPro;
using System.Text.RegularExpressions;
using Photon.Realtime;


public class launch : MonoBehaviourPunCallbacks
{




    // Start is called before the first frame update


    public void Awake()
    {
        PhotonNetwork.NetworkingClient.LoadBalancingPeer.SerializationProtocolType = ExitGames.Client.Photon.SerializationProtocol.GpBinaryV16;
        PhotonNetwork.AutomaticallySyncScene = true;
        ConnectForCloud();
    }

    public void ConnectForCloud()
    {
        Debug.Log("Trying to connect!");
        PhotonNetwork.GameVersion = "0.0.0";
        PhotonNetwork.PhotonServerSettings.AppSettings.UseNameServer = true;
        PhotonNetwork.PhotonServerSettings.AppSettings.Server = null;
        PhotonNetwork.PhotonServerSettings.AppSettings.Port = 0;
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = "CN";
        PhotonNetwork.ConnectUsingSettings();
        //PhotonNetwork.ConnectToMaster(ip, 5055, "58d222a1-6210-4438-b0df-af0d135e41d4");



    }



    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
        Join();
        base.OnConnectedToMaster();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Connect failed.");
        base.OnDisconnected(cause);
    }

    public void Join()
    {
        Debug.Log("Trying to join a room");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully join a room.");

        base.OnJoinedRoom();
        StartGame();
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("There is no room.");
        Create();
        base.OnJoinRandomFailed(returnCode, message);
    }

    public void Create()
    {

        Debug.Log("Create a room.");
        PhotonNetwork.CreateRoom("");
    }

    public void StartGame()
    {
        Debug.Log("Start the game.");



        PhotonNetwork.LoadLevel(1);



    }

}



