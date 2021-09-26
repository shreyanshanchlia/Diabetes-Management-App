using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterListManager : MonoBehaviour
{
    [SerializeField] private GameObject characterPanelHolder;
    [SerializeField] private Transform characterPanelElement;
    [SerializeField] List<Character> availableCharacters;
    [SerializeField] private EquipCharacter equipCharacter;
    public string selectedCharacter;

    private void Start()
    {
        if (SaveSystem.GetUserInfo().unlockedItems == null)
        {
            UserInfo userInfo = SaveSystem.GetUserInfo();
            userInfo.unlockedItems = new List<string>();
            userInfo.equippedCharacter = "default";
            SaveSystem.SaveUserInfo(userInfo);
        }
        equipCharacter.loadEquippedCharacter(CharacterIdToCharacter(SaveSystem.GetUserInfo().equippedCharacter));
    }

    private void OnEnable()
    {
        DestroyExisting();
        LoadAllCharacters();
    }

    public Character CharacterIdToCharacter(string id)
    {
        Debug.Log(id);
        return availableCharacters.Where(t => t.characterId == id).ToList()[0];
    }
    public void EquipCharacter()
    {
        equipCharacter.Equip(CharacterIdToCharacter(selectedCharacter));
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
