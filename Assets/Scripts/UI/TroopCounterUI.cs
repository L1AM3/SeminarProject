using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TroopCounterUI : MonoBehaviour
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
        AdditionArcherCount.text = TroopCounter.Instance.AdditionArcher.ToString();
        SubtractionSwordsmanCount.text = TroopCounter.Instance.SubtractionSwordsman.ToString();
        MultiplicationMarineCount.text = TroopCounter.Instance.MultiplicationMarine.ToString();
        DivisionDogFighterCount.text = TroopCounter.Instance.DivisionDogFighter.ToString();
    }
}
