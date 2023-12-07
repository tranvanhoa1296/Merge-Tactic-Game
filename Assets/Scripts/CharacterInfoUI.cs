using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInfoUI : MonoBehaviour
{
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI attackText;

    public void SetCharacterInfo(Character character)
    {
        typeText.text = "Type: " + character.Type.ToString();
        levelText.text = "Level: " + character.Level.ToString();
        healthText.text = "Health: " + character.Health;
        manaText.text = "Mana: " + character.Mana;
        defenseText.text = "Defense: " + character.Defense;
        attackText.text = "Attack: " + character.Attack;
    }
}
