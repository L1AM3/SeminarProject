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
    [SerializeField] private int EnemyBaseHealth;
    [SerializeField] private int HomeBaseHealth;
    public int TurnCounter;
    public event Action<int> HomeBaseDamaged;
    public event Action<int> EnemyBaseDamaged;

    public int GetHomeBaseHealth() => HomeBaseHealth;
    public int GetEnemyBaseHealth() => EnemyBaseHealth;

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

    public void DamageHomebase(int damage)
    {
        HomeBaseHealth -= Mathf.Abs(damage);

        HomeBaseDamaged?.Invoke(damage);

        if (HomeBaseHealth < 0)
        {
            //lose the game, loser (not kind)
        }
    }

    public void DamageEnemybase(int damage)
    {
        EnemyBaseHealth -= Math.Abs(damage);

        EnemyBaseDamaged?.Invoke(damage);

        if (EnemyBaseHealth < 0)
        {
            //win the game, nerd (kind)
        }
    }

    private void AddTroops()
    {
        TroopCounter.Instance.AddArcher();
        TroopCounter.Instance.AddSwordsman();

        if (TurnCounter % 3 == 0)
        {
            TroopCounter.Instance.AddMarine();
            TroopCounter.Instance.AddDogFighter();
        }
    }

    [SerializeField] private bool isTroopPlacing = true;

    public bool IsTroopPlacing() => isTroopPlacing;
    public void SetIsTroopPlacing(bool isTroopPlacingTurn)
    {
        isTroopPlacing = isTroopPlacingTurn;

        if(isTroopPlacing)
        {
            if (TroopCounter.Instance.AdditionArcher != 0)
            {
                troopButtons[0].color = Color.white;
            }

            if (TroopCounter.Instance.SubtractionSwordsman != 0)
            {
                troopButtons[1].color = Color.white;
            }

            if (TroopCounter.Instance.MultiplicationMarine != 0)
            {
                troopButtons[2].color = Color.white;
            }

            if (TroopCounter.Instance.DivisionDogFighter != 0)
            {
                troopButtons[3].color = Color.white;
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
