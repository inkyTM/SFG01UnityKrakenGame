using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSystem : MonoBehaviour
{
    [Header("Player Level Info")]
    [SerializeField]
    //player's current level
    public int playerLevel;
    [SerializeField]
    //player's current amount of XP
    public float currentXP;
    [SerializeField]
    //the amount of XP needed for the player to level up
    public float requiredXPtoLevelUp;
    [SerializeField]
    //changes the amount of XP needed for subsequent level ups by this amount
    public float increaseInRXP;

    [Header("Player Stats")]
    [SerializeField]
    //player's current HP
    public int currentHP;
    //player's current max HP
    public int maxHP;
    //how much the player's max HP increases per level
    public int maxHPIncrease;
    //player's current movement speed
    public int moveSpeed;
    //how much the player's movement speed increases per level
    public int moveSpeedIncrease;
    //player's current attack stat
    public int attack;
    //how much the player's attack stat increases per level
    public int attackIncrease;
    //player's current defense stat
    public int defense;
    //how much the player's defense stat increases per level
    public int defenseIncrease;
    //player's current jump power
    public int jumpPower;
    //how much the player's jump power increases per level
    public int jumpPowerIncrease;

    [Header("XPBar")]
    [SerializeField]
    public Slider slider;

    public void Update()
    {
        slider.maxValue = requiredXPtoLevelUp;
        slider.value = currentXP;
    }

    public LevelUpSystem()
    {
        playerLevel = 1;
        currentXP = 0;
        requiredXPtoLevelUp = 100;
        increaseInRXP = 50;
    }

    public void increaseXP(int increase)
    {
        currentXP += increase;
        if(currentXP >= requiredXPtoLevelUp)
        {
            playerLevel++;
            maxHP += maxHPIncrease;
            currentHP = maxHP;
            moveSpeed += moveSpeedIncrease;
            attack += attackIncrease;
            defense += defenseIncrease;
            jumpPower += jumpPowerIncrease;
            currentXP -= requiredXPtoLevelUp;
            requiredXPtoLevelUp += increaseInRXP;
        }
    }

    public void decreaseXP(int decrease)
    {
        currentXP -= decrease;
        if (currentXP < 0)
        {
            currentXP = 0;
        }
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

}
