using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField]
    private Behaviour[] componentsToDisable;

    private PhotonView view;


    
    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            // don't want to do much
        }
        else
        {
            foreach(Behaviour component in componentsToDisable)
            {
                component.enabled = false;
            }
        }
    }
}
