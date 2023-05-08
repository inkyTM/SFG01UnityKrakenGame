using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public float requiredXpToLevelUp;
    [SerializeField]
    //changes the amount of XP needed for subsequent level ups by this amount
    public float increaseInRXP;

    [Header("Player Stats")]
    [SerializeField]
    //player's current HP
    public int currentHP;
    [SerializeField]
    //player's current max HP
    public int maxHP;
    [SerializeField]
    //how much the player's max HP increases per level
    public int maxHPIncrease;
    [SerializeField]
    //whether or not the player's HP refills to full upon a level up
    public bool refillHP = true;
    [SerializeField]
    //player's current movement speed
    public int moveSpeed;
    [SerializeField]
    //how much the player's movement speed increases per level
    public int moveSpeedIncrease;
    [SerializeField]
    //player's current attack stat
    public int attack;
    [SerializeField]
    //how much the player's attack stat increases per level
    public int attackIncrease;
    [SerializeField]
    //player's current defense stat
    public int defense;
    [SerializeField]
    //how much the player's defense stat increases per level
    public int defenseIncrease;
    [SerializeField]
    //player's current jump power
    public int jumpPower;
    [SerializeField]
    //how much the player's jump power increases per level
    public int jumpPowerIncrease;

    [Header("UI")]
    [SerializeField]
    private LevelXPBar XPBar;
    [SerializeField]
    public bool _levelSoundActive = true;
    [SerializeField]
    AudioSource LevelUpSoundEffect;

    [Header("Test Features")]
    [SerializeField]
    public int _testIncrease = 20;
    [SerializeField]
    public int _testDecrease = 20;
    [SerializeField]
    public bool _testActive = true;

    public LevelUpSystem()
    {
        playerLevel = 1;
        currentXP = 0;
        requiredXpToLevelUp = 100;
        increaseInRXP = 50;
    }

    public void Start()
    {
        XPBar.displayXP(currentXP, requiredXpToLevelUp);
        XPBar.displayLevel(playerLevel);
    }

    public void increaseXP(int increase)
    {
        currentXP += increase;
        if(currentXP >= requiredXpToLevelUp)
        {
            levelUp();

        }
        displayUpdates();
    }

    public void levelUp()
    {
        //increase player level
        playerLevel++;
        //increase each of the player's stats by their designated amounts
        maxHP += maxHPIncrease;
        moveSpeed += moveSpeedIncrease;
        attack += attackIncrease;
        defense += defenseIncrease;
        jumpPower += jumpPowerIncrease;
        //refill the player's HP to full if this option was selected
        if (refillHP == true)
        {
            currentHP = maxHP;
        }
        //set up for the next level by reducing the player's XP and resetting the requirement
        currentXP -= requiredXpToLevelUp;
        requiredXpToLevelUp += increaseInRXP;
        if (_levelSoundActive == true)
        {
            playLevelUpSoundEffect();
        }
    }

    public void displayUpdates()
    {
        //update the display for both the player's XP and their Level
        XPBar.displayXP(currentXP, requiredXpToLevelUp);
        XPBar.displayLevel(playerLevel);
        XPBar.displayStats(currentHP, maxHP, moveSpeed, attack, defense, jumpPower);
    }

    public void playLevelUpSoundEffect()
    {
        AudioSource newSound = Instantiate(LevelUpSoundEffect);
        Destroy(newSound.gameObject, newSound.clip.length);
    }

    //used to test the functionality of the system
    public void Update()
    {
        if(_testActive == true)
        {
            if (Input.GetKeyDown("space"))
            {
                increaseXP(_testIncrease);
            }
            if (Input.GetKeyDown("backspace"))
            {
                decreaseXP(_testDecrease);
                XPBar.displayXP(currentXP, requiredXpToLevelUp);
            }
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
