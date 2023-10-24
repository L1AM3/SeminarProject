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
    private List<TroopBehavior> troops = new List<TroopBehavior>();
    private TroopType troopType = TroopType.None;

    private void OnEnable()
    {
        grid.TileSelected += OnTileSelected;
    }

    private void OnDisable()
    {
        grid.TileSelected -= OnTileSelected;
    }

    private void OnTileSelected(Tile tile)
    {
        if (tile.gridCoords.x != 0)
            return;

        Debug.Log("im in");
        if (troopType == TroopType.None)
            return;

        if (tile.HasTroop() && tile.GetTroopType().GetTroopType() == troopType)
        {
            if (DecreaseTroopCount(troopType))
            {
                tile.GetTroopType().TroopStacking();
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
                if (TroopCounter.DivisionDogFighter >= 1)
                {
                    TroopCounter.DivisionDogFighter -= 1;
                    return true;
                }
                break;

            case TroopType.MultiplicationMarine:
                if (TroopCounter.MultiplicationMarine >= 1)
                {
                    TroopCounter.MultiplicationMarine -= 1;
                    return true;
                }
                break;

            case TroopType.SubtractionSwordsman:
                if (TroopCounter.SubtractionSwordsman >= 1)
                {
                    TroopCounter.SubtractionSwordsman -= 1;
                    return true;
                }
                break;

            case TroopType.AdditionArcher:
                if (TroopCounter.AdditionArcher >= 1)
                {
                    TroopCounter.AdditionArcher -= 1;
                    return true;
                }
                break;
        }
        return false;
    }

    public void SpawnTroop(int prefabIndex, Tile tile)
    {
        TroopBehavior troopBehave = Instantiate(troopPrefabs[prefabIndex], tile.transform.position, Quaternion.identity, transform);
        troopBehave.TroopGridsCoord = tile.gridCoords;
        troopBehave.Grid = grid;
        troopBehave.Placement = this;
        troopBehave.SetType((TroopType) prefabIndex);

        troops.Add(troopBehave);

        tile.SetTroop(troopBehave);
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
