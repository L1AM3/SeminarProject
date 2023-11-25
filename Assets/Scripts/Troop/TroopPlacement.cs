using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TroopType
{
    None = -1,
    AdditionArcher,
    SubtractionSwordsman,
    MultiplicationMarine,
    DivisionDogFighter,
}

public class TroopPlacement : MonoBehaviour
{
    [SerializeField] private TroopBehavior[] troopPrefabs;
    [SerializeField] private GridManager grid;
    [SerializeField] private int damageCap;
    [SerializeField] private int maxTurnSpawn;
    private List<TroopBehavior> troops = new List<TroopBehavior>();
    private TroopType troopType = TroopType.None;
    private int currentTroopsSpawned = 0;

    private void OnEnable()
    {
        grid.TileSelected += OnTileSelected;
        TroopManager.TroopTurnFinished += ResetTroopCounter;
    }

    private void ResetTroopCounter()
    {
        currentTroopsSpawned = 0;
    }

    private void OnDisable()
    {
        grid.TileSelected -= OnTileSelected;
    }

    private void OnTileSelected(Tile tile)
    {
        if (!GameManager.Instance.IsTroopPlacing()) return;

        if (tile.gridCoords.x != 0)
            return;

        if (currentTroopsSpawned >= maxTurnSpawn) return;

        TroopBehavior troopBehavior = tile.GetComponentInChildren<TroopBehavior>();

        if (troopType == TroopType.None || (troopBehavior && troopType != troopBehavior.GetTroopType()))
            return;


        Debug.Log("im in");

        if (troopBehavior && troopBehavior.GetTroopType() == troopType)
        {
            if (troopBehavior.TroopInfo.Damage > damageCap) return;

            if (DecreaseTroopCount(troopType))
            {
                troopBehavior.TroopStacking();
                currentTroopsSpawned++;
            }

            return;
        }

        if (DecreaseTroopCount(troopType))
        {
            SpawnTroop((int)troopType, tile);
        }
    }

    public bool DecreaseTroopCount(TroopType type)
    {
        switch (type)
        {
            case TroopType.DivisionDogFighter:
                if (TroopCounter.Instance.DivisionDogFighter >= 1)
                {
                    TroopCounter.Instance.DivisionDogFighter -= 1;

                    if (TroopCounter.Instance.DivisionDogFighter <= 0)
                    {
                        GameManager.Instance.troopButtons[3].color = Color.gray;
                    }

                    return true;
                }
                break;

            case TroopType.MultiplicationMarine:
                if (TroopCounter.Instance.MultiplicationMarine >= 1)
                {
                    TroopCounter.Instance.MultiplicationMarine -= 1;

                    if (TroopCounter.Instance.MultiplicationMarine <= 0)
                    {
                        GameManager.Instance.troopButtons[2].color = Color.gray;
                    }

                    return true;
                }
                break;

            case TroopType.SubtractionSwordsman:
                if (TroopCounter.Instance.SubtractionSwordsman >= 1)
                {
                    TroopCounter.Instance.SubtractionSwordsman -= 1;


                    if (TroopCounter.Instance.SubtractionSwordsman <= 0)
                    {
                        GameManager.Instance.troopButtons[1].color = Color.gray;
                    }

                    return true;
                }
                break;

            case TroopType.AdditionArcher:
                if (TroopCounter.Instance.AdditionArcher >= 1)
                {
                    TroopCounter.Instance.AdditionArcher -= 1;


                    if (TroopCounter.Instance.AdditionArcher <= 0)
                    {
                        GameManager.Instance.troopButtons[0].color = Color.gray;
                    }

                    return true;
                }
                break;
        }
        return false;
    }

    public void SpawnTroop(int prefabIndex, Tile tile)
    {
        TroopBehavior troopBehave = Instantiate(troopPrefabs[prefabIndex], tile.transform.position, Quaternion.identity, tile.transform);
        troopBehave.TroopGridsCoord = tile.gridCoords;
        troopBehave.Grid = grid;
        troopBehave.Placement = this;
        troopBehave.SetType((TroopType) prefabIndex);

        troops.Add(troopBehave);
        currentTroopsSpawned++;
    }

    public void SelectTroop(TroopBehavior troop)
    {
        foreach (var troopBehave in troops)
        {
            troopBehave.IsTroopSelected = false;
        }

        troop.IsTroopSelected = true;
    }

    public void SetType(TroopType type)
    {
        troopType = type;
    }
}
