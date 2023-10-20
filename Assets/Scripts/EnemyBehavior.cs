using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public TroopScriptableObject EnemyInfo;
    public GridManager Grid;
    [HideInInspector] public Vector2Int TroopGridsCoord;
    private BreadthFirstSearch target;

    public void SetTarget(BreadthFirstSearch target) => this.target = target;
    public void SetGridCoords(Vector2Int gridCoords) => TroopGridsCoord = gridCoords;

    private void OnEnable()
    {
        TroopManager.TroopMoved += MoveEnemy;
        
    }

    private void OnDisable()
    {
        TroopManager.TroopMoved -= MoveEnemy;
    }

    public Vector2Int GetMovementDir()
    {
        Vector2Int moveDir = target.GetPathChart()[TroopGridsCoord] - TroopGridsCoord;

        return moveDir;
    }

    public void MoveEnemy()
    {
        Vector2Int dir = GetMovementDir();
        Tile theFuckingTile = Grid.GetTileFromDictionary(TroopGridsCoord + dir);

        if (theFuckingTile != null)
        {
            TroopGridsCoord += dir;
            transform.position = theFuckingTile.transform.position;
        }
    }
}
