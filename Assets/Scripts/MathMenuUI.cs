using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathMenuUI : MonoBehaviour
{
    public TMP_Text AdditionArcherCount;
    public TMP_Text SubtractionSwordsmanCount;
    public TMP_Text MultiplicationMarineCount;
    public TMP_Text DivisionDogFighterCount;

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        AdditionArcherCount.text = TroopCounter.AdditionArcher.ToString();
        SubtractionSwordsmanCount.text = TroopCounter.SubtractionSwordsman.ToString();
        MultiplicationMarineCount.text = TroopCounter.MultiplicationMarine.ToString();
        DivisionDogFighterCount.text = TroopCounter.DivisionDogFighter.ToString();
    }
}
