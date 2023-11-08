using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateSwitcher : MonoBehaviour
{
    public Button PlacementButton;
    public Button EndTurn;

    public EnemySpawner Spawner;

    private void Start()
    {
        Spawner.EnemyTurnFinished += StartPlayerTurn;
    }

    private void StartPlayerTurn()
    {
        GameManager.Instance.SetIsTroopPlacing(true);
        PlacementButton.gameObject.SetActive(true);
    }

    public void EndPlacementPhase()
    {
        GameManager.Instance.SetIsTroopPlacing(false);
        PlacementButton.gameObject.SetActive(false);
        EndTurn.gameObject.SetActive(true);
    }

    public void EndMovementPhase()
    {
        EndTurn.gameObject.SetActive(false);
        TroopManager.InvokeTroopTurnFinished();
    }
}
