using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class ConnectionHandler : MonoBehaviourPunCallbacks
{
    public Button playButton;
    public string sceneName;
    public TMP_InputField playerNameInput;
    public TMP_Text networkStatusText;

    
    void Awake()
    {
        ConfigureInput(false);
        playerNameInput.text = PlayerPrefs.GetString("Player Name");

        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.ConnectUsingSettings();
    }

    private void ConfigureInput(bool enable)
    {
        playerNameInput.interactable = enable;
        playButton.interactable = enable;
    }

    public override void OnConnectedToMaster()
    {
        networkStatusText.text = "Connected to MS";

        ConfigureInput(true);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        networkStatusText.text = "Disconnected for reasons" + cause;
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(sceneName);
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // Connection to room fails because either the room hasn't been created (so create one)
        // or the room is full (so create a new room))
        PhotonNetwork.CreateRoom("Marionette", new RoomOptions
        {
            MaxPlayers = 20
        }) ;
    }

    public void PlayMarionette()
    {
        if(playerNameInput == null)
        {
            networkStatusText.text = "Enter a name";
            return;
        }

        PhotonNetwork.NickName = playerNameInput.text;

        PhotonNetwork.JoinRandomRoom();
    }

}
