using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkAvatarSetup : MonoBehaviour
{
    private PhotonView photonView;
    public GameObject mycharacter;
    public int characterValue;
    public float characterOffset = 2f;

    void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            photonView.RPC("RPC_Character", RpcTarget.AllBuffered, PlayerInfo.instance.selectedCharacter);
        }

    }


    [PunRPC]
    private void RPC_Character(int character)
    {
        characterValue = character;

        mycharacter = Instantiate(PlayerInfo.instance.allCharacters[character], new Vector3(transform.position.x, 1.7f, transform.position.z + characterOffset), transform.rotation);

    }
    
   
}
