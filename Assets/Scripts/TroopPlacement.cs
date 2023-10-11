using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TroopPlacement : MonoBehaviour
{
    [SerializeField] private GameObject[] troopPrefabs;
    [SerializeField] private TroopScriptableObject[] troops;
    private int troopType = -1;
    [SerializeField] private GridManager grid;

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
        Debug.Log("im in");
        if (troopType == -1)
            return;
        if (!tile.HasTroop())
        {
            tile.InverthasTroop();
            Instantiate(troopPrefabs[troopType], tile.transform.position, Quaternion.identity, tile.transform);
        }

        switch (troopType)
        {
            case 3:
                if (TroopManager.DivisionDogFighter >= 1)
                {
                    Instantiate(troopPrefabs[troopType], tile.transform);
                    TroopManager.DivisionDogFighter -= 1;
                }
                break;

            case 2:
                if (TroopManager.MultiplicationMarine >= 1)
                {
                    Instantiate(troopPrefabs[troopType], tile.transform);
                    TroopManager.MultiplicationMarine -= 1;
                }
                break;

            case 1:
                if (TroopManager.SubtractionSwordsman >= 1)
                {
                    Instantiate(troopPrefabs[troopType], tile.transform);
                    TroopManager.SubtractionSwordsman -= 1;
                }
                break;

            case 0:
                if (TroopManager.AdditionArcher >= 1)
                {
                    Instantiate(troopPrefabs[troopType], tile.transform);
                    TroopManager.AdditionArcher -= 1;
                }
                break;

            default:
                Debug.Log("Too Poor");
                break;
        }
    }

    public void SetType(int type)
    {
        troopType = type;
    }
}
