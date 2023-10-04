using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathMenuUI : MonoBehaviour
{
    public Timer timer;
    private float TimeToDisplay;

    public TMP_Text AdditionArcherCount;
    public TMP_Text SubtractionSwordsmanCount;
    public TMP_Text MultiplicationMarineCount;
    public TMP_Text DivisionDogFighterCount;

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        timer.DisplayTime(TimeToDisplay);
    }

    private void UpdateUI()
    {
        AdditionArcherCount.text = TroopManager.AdditionArcher.ToString();
        SubtractionSwordsmanCount.text = TroopManager.SubtractionSwordsman.ToString();
        MultiplicationMarineCount.text = TroopManager.MultiplicationMarine.ToString();
        DivisionDogFighterCount.text = TroopManager.DivisionDogFighter.ToString();
    }
}