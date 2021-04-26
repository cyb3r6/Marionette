using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharcter : MonoBehaviour
{
   public void ChooseCharacter(int character)
   {
        if(PlayerInfo.instance.selectedCharacter != null)
        {
            PlayerInfo.instance.selectedCharacter = character;
            PlayerPrefs.SetInt("Character", character);
        }
   }
}
