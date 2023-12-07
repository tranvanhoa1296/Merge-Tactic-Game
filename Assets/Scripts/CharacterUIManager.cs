using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIManager : MonoBehaviour
{
    public GameObject characterInfoPrefab;
    public Transform characterInfoPanel; // Panel để chứa các thông tin nhân vật

    public void DisplayCharacters(List<Character> characters)
    {
      
        foreach (Transform child in characterInfoPanel)
        {
            Destroy(child.gameObject);
        }

        
        foreach (Character character in characters)
        {
            GameObject infoObj = Instantiate(characterInfoPrefab, characterInfoPanel);
            CharacterInfoUI infoUI = infoObj.GetComponent<CharacterInfoUI>();
            infoUI.SetCharacterInfo(character);
        }
    }
    public void CreateCharacterUI(Character character)
    {
        GameObject infoObj = Instantiate(characterInfoPrefab, characterInfoPanel);
        CharacterInfoUI infoUI = infoObj.GetComponent<CharacterInfoUI>();
        infoUI.SetCharacterInfo(character);
    }
}
