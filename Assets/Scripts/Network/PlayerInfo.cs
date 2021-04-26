using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;
    public int selectedCharacter;
    public GameObject[] allCharacters;

    
    void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    
    void Start()
    {
        if (PlayerPrefs.HasKey("Character"))
        {
            selectedCharacter = PlayerPrefs.GetInt("Character");
        }
        else
        {
            selectedCharacter = 0;
            PlayerPrefs.SetInt("Character", selectedCharacter);
        }
    }
}
