using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelXPBar : MonoBehaviour
{
    private int _playerLevel;
    private TextMeshProUGUI _levelText;
    private void Update()
    {
        //_playerLevel = 
        //_currentLevel.text = "Level " + LevelUpSystem.playerLevel
    }

    [Header("XPBar")]
    [SerializeField]
    public Slider slider;

    public void Update(LevelUpSystem levelUpSystem)
    {
        slider.maxValue = levelUpSystem.requiredXPtoLevelUp;
        slider.value = levelUpSystem.currentXP;
    }
}
