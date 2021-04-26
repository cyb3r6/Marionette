using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject oVRPlayerPrefab;

    public float characterOffset = 2f; 

    void Start()
    {
        var numberofPlayers = PhotonNetwork.CurrentRoom.PlayerCount;

        var newPlayer = PhotonNetwork.Instantiate(oVRPlayerPrefab.name, new Vector3(numberofPlayers * characterOffset, 0, 0), Quaternion.identity);

    }

    
}
