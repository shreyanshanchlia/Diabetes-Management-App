using System;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable once RedundantUsingDirective
using FantomLib;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterListManager))]
public class EquipCharacter : MonoBehaviour
{
    [SerializeField] Image equippedCharacterImage;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI characterDescriptionText;

    public void loadEquippedCharacter(Character character)
    {
        equippedCharacterImage.sprite = character.image;
        characterNameText.text = character.characterName;
        characterDescriptionText.text = character.characterDescription;
    }
    
    [Obsolete("", true)]
    public void EquipAndSave(Character character)
    {
        UserInfo userInfo = SaveSystem.GetUserInfo();
        if (userInfo.unlockedItems == null)
        {
            userInfo.unlockedItems = new List<string>();
        }
        if (userInfo.unlockedItems.Contains(character.characterId))
        {
            userInfo.equippedCharacter = character.characterId;
            loadEquippedCharacter(character);
        }
        else
        {
            //TODO: Have unlock UI Popup before buying the item.
            BuyItem(character);
        }
    }

    public void Equip(Character character)
    {
        List<string> unlocked = BaseSave.Load(BaseSave.UNLOCKED, new List<string>());
        if (unlocked == null)
        {
            unlocked = new List<string>();
        }
        if (unlocked.Contains(character.characterId))
        {
            BaseSave.PrefSave(BaseSave.PREFS_EQUIPPEDCHARACTER, character.characterId);
            loadEquippedCharacter(character);
        }
        else
        {
            //TODO: Have unlock UI Popup before buying the item.
            BuyItem(character);
        }
    }

    public void BuyItem(Character character)
    {
        //UserInfo userInfo = SaveSystem.GetUserInfo();
        int sparkleCoins = BaseSave.Load(BaseSave.SPARKLES, 0);
        if (sparkleCoins >= character.unlockCost)
        {
            sparkleCoins -= character.unlockCost;
            //SaveSystem.SaveUserInfo(userInfo);
            BaseSave.Save(BaseSave.SPARKLES, sparkleCoins);
        }
        else
        {
            #if !UNITY_EDITOR
            AndroidPlugin.ShowToast($"Not enough sparkles.");
            #else 
            Debug.Log($"Not enough sparkles.");
            #endif
        }
    }
}
