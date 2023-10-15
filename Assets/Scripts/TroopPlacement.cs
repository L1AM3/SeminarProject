using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TroopPlacement : MonoBehaviour
{
    [SerializeField] private TroopBehavior[] troopPrefabs;
    [SerializeField] private TroopScriptableObject[] troopData;
    private int troopType = -1;
    [SerializeField] private GridManager grid;
    private List<TroopBehavior> troops = new List<TroopBehavior>();

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
        if (troopType == -1)
            return;

        if (!tile.HasTroop())
        {
            tile.InverthasTroop();
            //Instantiate(troopPrefabs[troopType], tile.transform.position, Quaternion.identity, tile.transform);
        }

        switch (troopType)
        {
            case 3:
                if (TroopManager.DivisionDogFighter >= 1)
                {
                    SpawnTroop(3, tile);
                    TroopManager.DivisionDogFighter -= 1;
                }
                break;

            case 2:
                if (TroopManager.MultiplicationMarine >= 1)
                {
                    SpawnTroop(2, tile);
                    TroopManager.MultiplicationMarine -= 1;
                }
                break;

            case 1:
                if (TroopManager.SubtractionSwordsman >= 1)
                {
                    SpawnTroop(1, tile);
                    TroopManager.SubtractionSwordsman -= 1;
                }
                break;

            case 0:
                if (TroopManager.AdditionArcher >= 1)
                {
                    SpawnTroop(0, tile);
                    TroopManager.AdditionArcher -= 1;
                }
                break;

            default:
                Debug.Log("Too Poor");
                break;
        }
    }

    public void SpawnTroop(int prefabIndex, Tile tile)
    {
        TroopBehavior troopBehave = Instantiate(troopPrefabs[prefabIndex], tile.transform.position, Quaternion.identity, transform);
        troopBehave.TroopGridsCoord = tile.gridCoords;
        troopBehave.Grid = grid;
        troopBehave.TroopInfo = troopData[prefabIndex];
        troopBehave.Placement = this;

        troops.Add(troopBehave);
    }

    public void SelectTroop(TroopBehavior troop)
    {
        foreach (var troopBehave in troops)
        {
            troopBehave.IsTroopSelected = false;
        }

        troop.IsTroopSelected = true;
    }

    public void SetType(int type)
    {
        troopType = type;
    }
}
