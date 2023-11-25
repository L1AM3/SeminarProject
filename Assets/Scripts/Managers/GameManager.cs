using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public EnemySpawner Spawn;
    public List<Image> troopButtons = new(4);
    public int EnemyBaseHealth;
    public int HomeBaseHealth;
    public int TurnCounter;

    private void Awake()
    {
        //Singleton garbage
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        //Singleton garbage done

    }

    private void Start()
    {
        Spawn.EnemyTurnFinished += AddTroops;
    }

    private void AddTroops()
    {
        TroopCounter.AddArcher();
        TroopCounter.AddSwordsman();

        if (TurnCounter % 3 == 0)
        {
            TroopCounter.AddMarine();
            TroopCounter.AddDogFighter();
        }
    }

    [SerializeField] private bool isTroopPlacing = true;

    public bool IsTroopPlacing() => isTroopPlacing;
    public void SetIsTroopPlacing(bool isTroopPlacingTurn)
    {
        isTroopPlacing = isTroopPlacingTurn;

        if(isTroopPlacing)
        {
            foreach(var button in troopButtons)
            {
                button.color = Color.white;
            }
        }
        else
        {
            foreach (var button in troopButtons)
            {
                button.color = Color.grey;
            }
        }
    }
}
