using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public enum CharacterType { Type1, Type2, Type3, Type4, Type5, Type6 }
    public enum CharacterLevel { Level1, Level2, Level3 }

    public CharacterType Type { get; private set; }
    public CharacterLevel Level { get; private set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Defense { get; set; }
    public int Attack { get; set; }

    public Character(CharacterType type)
    {
        Type = type;
        Level = CharacterLevel.Level1;
        Health = Random.Range(50, 150);   
        Mana = Random.Range(20, 80);      
        Defense = Random.Range(5, 20);   
        Attack = Random.Range(10, 30);
    }

    public void LevelUp()
    {
        if (Level < CharacterLevel.Level3)
        {
            Level++;
            
            Health += 50;
            Mana += 25;
            Defense += 5;
            Attack += 10;
        }
    }

   
}