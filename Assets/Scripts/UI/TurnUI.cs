using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TurnUI : MonoBehaviour
{
    public TMP_Text TurnText;
    public TMP_Text TurnCounterText;
    public EnemySpawner Spawn;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTurnText();

        TroopManager.TroopTurnFinished += EnemyTurnText;
        Spawn.EnemyTurnFinished += PlayerTurnText;
    }

    private void Update()
    {
        TurnCounter();
    }

    private void PlayerTurnText()
    {
        TurnText.text = "Your Turn";
    }

    private void EnemyTurnText()
    {
        TurnText.text = "Enemy Turn";
    }

    private void TurnCounter()
    {
        TurnCounterText.text = GameManager.Instance.TurnCounter.ToString();
    }
}
