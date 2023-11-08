using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TurnUI : MonoBehaviour
{
    public TMP_Text TurnText;
    public EnemySpawner Spawn;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTurnText();

        TroopManager.TroopTurnFinished += EnemyTurnText;
        Spawn.EnemyTurnFinished += PlayerTurnText;
    }

    private void PlayerTurnText()
    {
        TurnText.text = "Your Turn";
    }

    private void EnemyTurnText()
    {
        TurnText.text = "Enemy Turn";
    }
}
