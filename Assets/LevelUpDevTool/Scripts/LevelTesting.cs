using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTesting : MonoBehaviour
{
    private void Awake()
    {
        LevelUpSystem levelUpSystem = new LevelUpSystem();
        Debug.Log(levelUpSystem.GetPlayerLevel());
        levelUpSystem.increaseXP(50);
        Debug.Log(levelUpSystem.GetPlayerLevel());
        levelUpSystem.increaseXP(60);
        Debug.Log(levelUpSystem.GetPlayerLevel());
    }
}
