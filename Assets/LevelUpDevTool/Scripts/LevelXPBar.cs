using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelXPBar : MonoBehaviour
{
    [Header("XPBar")]
    [SerializeField]
    Slider _XPSlider;
    public TextMeshProUGUI _playerLevelText;
    public TextMeshProUGUI _playerXPText;
    public TextMeshProUGUI _playerStatsText;
    [SerializeField]
    //whether or not the player's Level, XP, and Stats will be visible
    public bool _visibleInfo = true;

    public void Start()
    {
        if (_visibleInfo == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void displayLevel(int _playerLevel)
    {
        _playerLevelText.text = "Lv: " + _playerLevel.ToString();
    }

    public void displayXP(float _currentXP, float _maxXP)
    {
        _XPSlider.maxValue = _maxXP;
        _XPSlider.value = _currentXP;
        _playerXPText.text = _currentXP.ToString() + "/" + _maxXP.ToString();
    }

    public void displayStats(int _currentHP, int _maxHP, int _moveSpeed, int _attack, int _defense, int _jumpPower)
    {
        _playerStatsText.text = "Hp:" + _currentHP.ToString() + "/" + _maxHP.ToString() + " Spd:" + _moveSpeed.ToString() +
            " Atk:" + _attack.ToString() + " Def:" + _defense.ToString() + " Jmp:" + _jumpPower.ToString();
    }
 }
