using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHolder : MonoBehaviour
{
    [SerializeField] Image background;
    [SerializeField] private Image characterImage;
    [SerializeField] private GameObject buyHolder;
    [SerializeField] private Image coinBuyImage;
    [SerializeField] private TextMeshProUGUI buyCost;
    private Character character;
    private CharacterState characterState = CharacterState.OutOfStock;
    public enum CharacterState
    {
        OutOfStock, Bought, Available, Equipped  
    }

    public void SelectCharacter()
    {
        FindObjectOfType<CharacterListManager>().selectedCharacter = character.characterId;
    }

    public void CreateCharacter(Character _character, CharacterState _characterState = CharacterState.OutOfStock)
    {
        character = _character;
        characterState = _characterState;
        
        if (_characterState == CharacterState.OutOfStock)
        {
            characterImage.sprite = _character.image;
            coinBuyImage.gameObject.SetActive(false);
            buyCost.text = "N/A";
        }
        else if (_characterState == CharacterState.Bought)
        {
            characterImage.sprite = _character.image;
            buyHolder.gameObject.SetActive(false);
        }
        else if (_characterState == CharacterState.Available)
        {
            characterImage.sprite = _character.image;
            buyCost.text = _character.unlockCost.ToString();
            
        }
        else if (_characterState == CharacterState.Equipped)
        {
            characterImage.sprite = _character.image;
            buyHolder.gameObject.SetActive(false);
        }
    }
}
