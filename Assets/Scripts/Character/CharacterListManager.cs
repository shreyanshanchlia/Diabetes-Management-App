using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterListManager : MonoBehaviour
{
    [SerializeField] private GameObject characterPanelHolder;
    [SerializeField] private Transform characterPanelElement;
    [SerializeField] List<Character> availableCharacters;

    public string selectedCharacter;
    
    private void OnEnable()
    {
        DestroyExisting();
        LoadAllCharacters();
    }

    private void LoadAllCharacters()
    {
        foreach (Character character in availableCharacters)
        {
            GameObject shownCharacter = Instantiate(characterPanelElement, characterPanelHolder.transform).gameObject;
            shownCharacter.GetComponent<CharacterHolder>().CreateCharacter(character, CharacterHolder.CharacterState.Available);
        }
    }

    private void DestroyExisting()
    {
        foreach (Transform existingHolders in characterPanelHolder.transform)
        {
            Destroy(existingHolders.gameObject);
        }
    }
}
