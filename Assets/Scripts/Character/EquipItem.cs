using UnityEngine;

public class EquipItem : MonoBehaviour
{
    [SerializeField] private string equipmentSlotName;
    
    public void Equip(Character character)
    {
        UserInfo userInfo = SaveSystem.GetUserInfo();

        if (userInfo.unlockedItems.Contains(character.characterId))
        {
            userInfo.equippedCharacter = character.characterId;
        }
        else
        {
            //TODO: Have unlock UI Popup before buying the item.
            BuyItem(character);
        }
    }

    public void BuyItem(Character character)
    {
        UserInfo userInfo = SaveSystem.GetUserInfo();
        if (userInfo.sparklesCoins >= character.unlockCost)
        {
            userInfo.sparklesCoins -= character.unlockCost;
            SaveSystem.SaveUserInfo(userInfo);
        }
        else
        {
            #if !UNITY_EDITOR
            
            #endif
        }
    }
}
