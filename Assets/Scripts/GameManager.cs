using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Button spawnButton;
    public GameObject characterPrefab;
    public Camera mainCamera; // Reference to the camera
    public float spawnAreaWidth = 5.0f; // Width of the spawn area on the screen
    public float spawnAreaHeight = 5.0f; // Height of the spawn area on the screen
    public List<CharacterData> characterTemplates = new List<CharacterData>();
    public int maxCharacters = 6; // Số lượng tối đa nhân vật

    private List<Character> spawnedCharacters = new List<Character>();
    private int characterCount = 0; // Biến đếm số lượng nhân vật đã sinh ra

    private void Start()
    {
        spawnButton.onClick.AddListener(SpawnCharacter);
    }

    private void SpawnCharacter()
    {
        if (characterCount < maxCharacters)
        {
            // Lấy một CharacterData ngẫu nhiên từ danh sách characterTemplates
            CharacterData randomCharacterData = characterTemplates[Random.Range(0, characterTemplates.Count)];

            // Tạo một ScriptableObject mới từ CharacterData
            Character newCharacter = CreateCharacterFromData(randomCharacterData);

            // Tạo một vị trí ngẫu nhiên trong vùng spawn trên màn hình
            float randomX = Random.Range(Screen.width * 0.5f - spawnAreaWidth * 0.5f, Screen.width * 0.5f + spawnAreaWidth * 0.5f);
            float randomY = Random.Range(Screen.height * 0.5f - spawnAreaHeight * 0.5f, Screen.height * 0.5f + spawnAreaHeight * 0.5f);

            Vector3 randomScreenPosition = new Vector3(randomX, randomY, 0);
            Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(randomScreenPosition);
            spawnPosition.z = 0; // Đảm bảo rằng nhân vật sẽ spawn ở một tầng z cố định

            // Spawn nhân vật vào vị trí SpawnPoint
            GameObject spawnedObject = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

            // Thực hiện các tùy chỉnh cho đối tượng đã spawn
            CharacterDis characterDisplay = spawnedObject.GetComponent<CharacterDis>();
            if (characterDisplay != null)
            {
                characterDisplay.SetCharacterStats(randomCharacterData);
            }

            // Thêm nhân vật vào danh sách đã spawn và tăng biến đếm
            spawnedCharacters.Add(newCharacter);
            characterCount++;
        }
    }

    private Character CreateCharacterFromData(CharacterData characterData)
    {
        // Tạo một Character mới từ ScriptableObject CharacterData
        Character newCharacter = new Character(characterData.characterName, characterData.level);

        // Gán các giá trị từ CharacterData cho Character
        newCharacter.health = characterData.baseHealth;
        newCharacter.mana = characterData.baseMana;
        newCharacter.defense = characterData.baseDefense;
        newCharacter.attack = characterData.baseAttack;
        newCharacter.skills = new SkillSet(
            new Skill(characterData.normalAttack.name, characterData.normalAttack.damage),
            new Skill(characterData.passiveSkill.name, characterData.passiveSkill.damage),
            new Skill(characterData.activeSkill.name, characterData.activeSkill.damage)
        );

        // Các công việc khác để khởi tạo nhân vật

        return newCharacter;
    }
}
