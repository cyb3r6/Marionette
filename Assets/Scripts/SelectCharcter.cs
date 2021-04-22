using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharcter : MonoBehaviour
{
    [SerializeField]
    private GameObject ortiz;

    [SerializeField]
    private GameObject ty;

    [SerializeField]
    private GameObject selectedCharacter;

    
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SelectOrtiz()
    {
        selectedCharacter = ortiz;
    }

    public void SelectTy()
    {
        selectedCharacter = ty;
    }
    
}
