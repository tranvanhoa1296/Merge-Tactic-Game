using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameManager gameManager;

    public void OnSpawnButtonClick()
    {
        gameManager.SpawnCharacter();
    }

    public void OnMergeButtonClick()
    {
        gameManager.MergeCharacters();
    }
}
