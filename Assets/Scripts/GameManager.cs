using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Character> characters;
    public GameObject characterPrefab;
    public CharacterUIManager characterUIManager;

    private void Start()
    {
        characters = new List<Character>();
    }

    public void SpawnCharacter()
    {
        // Chỉ tạo mới nhân vật nếu số lượng chưa đạt 6
        if (characters.Count < 6)
        {
            for (int i = characters.Count; i < 6; i++)
            {
                Character.CharacterType randomType = (Character.CharacterType)Random.Range(0, 6);
                Character newCharacter = new Character(randomType);
                characters.Add(newCharacter);

                // Tạo GameObject và cập nhật UI
                GameObject newCharacterObj = Instantiate(characterPrefab, GetRandomPosition(), Quaternion.identity);
                newCharacterObj.GetComponent<CharacterInfoUI>().SetCharacterInfo(newCharacter); // Giả sử có component này
            }
        }
        characterUIManager.DisplayCharacters(characters);
    }

    Vector3 GetRandomPosition()
    {
        Camera mainCamera = Camera.main;
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        
        float x = Random.Range(mainCamera.transform.position.x - width / 2 * 0.7f, mainCamera.transform.position.x + width / 2 * 0.7f);
        float y = Random.Range(mainCamera.transform.position.y - height / 2 * 0.7f, mainCamera.transform.position.y + height / 2 * 0.7f);

        return new Vector3(x, y, 0);
    }

   
    public void MergeCharacters()
    {
       
        var mergeDict = new Dictionary<(Character.CharacterType, Character.CharacterLevel), Character>();

        foreach (var character in characters)
        {
            var key = (character.Type, character.Level);

            if (mergeDict.ContainsKey(key))
            {
               
                mergeDict[key].LevelUp();
            }
            else
            {
                
                mergeDict[key] = character;
            }
        }

       
        characters = new List<Character>(mergeDict.Values);

       
        characterUIManager.DisplayCharacters(characters);
    }
}
