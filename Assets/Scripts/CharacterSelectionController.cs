using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionController : MonoBehaviour
{
    [SerializeField]
    private Transform characterSpawnTransform;

    [SerializeField]
    private RagdollController ragDollController;

    private Character character;

    public GameObject characterPrefab;
    
    void OnEnable()
    {
        character = GetComponentInChildren<Character>();
        ChangeCharacter(characterPrefab);
        ConnectCharacterToHand();
    }

    
    void Update()
    {
        
    }

    public void ChangeCharacter(GameObject prefab)
    {
        if(characterSpawnTransform.childCount > 1)
        {
            Destroy(characterSpawnTransform.GetChild(0));
        }

        GameObject character = Instantiate(prefab, characterSpawnTransform);
        character.transform.localPosition = Vector3.zero;
    }

    public void ConnectCharacterToHand()
    {
        for(int i = 0; i < character.characterJoints.Count; i++)
        {
            ragDollController.marionetteVisuals[i].fingerTip = character.characterJoints[i];
        }
    }

}
