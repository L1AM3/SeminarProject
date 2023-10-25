using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public TroopScriptableObject EnemyInfo;
    private GridManager Grid;
    public Vector2Int TroopGridsCoord;
    private BreadthFirstSearch target;

    public void DebuffHealth(int debuffval)
    {
        if (debuffval >= EnemyInfo.Health)
        {
            EnemyInfo.Health = 1;
            return;
        }

        EnemyInfo.Health -= debuffval;
    }

    public void DebuffDivHealth(int debuffval)
    {
        Debug.Assert(debuffval > 0);
        float newHealth = (float) EnemyInfo.Health / debuffval;
        EnemyInfo.Health = (int) Mathf.Ceil(newHealth);
    }

    public bool KillEnemy(int damage)
    {
        if (damage >= EnemyInfo.Health)
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }

    public void SetTarget(BreadthFirstSearch target) => this.target = target;
    public void SetGridCoords(Vector2Int gridCoords) => TroopGridsCoord = gridCoords;
    public void SetGrid(GridManager manager) => Grid = manager;

    public Vector2Int GetMovementDir()
    {
        Vector2Int moveDir = target.GetPathChart()[TroopGridsCoord] - TroopGridsCoord;

        return moveDir;
    }

    public void MoveEnemy()
    {
        if (target == null)
        {
            target = TroopManager.troops[Random.Range(0, TroopManager.troops.Count)].GetComponent<BreadthFirstSearch>();

            //if there are no targets we return out
            if (target == null) return;
        }

        Vector2Int dir = GetMovementDir();
        Tile theFuckingTile = Grid.GetTileFromDictionary(TroopGridsCoord + dir);

        if (theFuckingTile != null)
        {
            TroopGridsCoord += dir;
            transform.position = theFuckingTile.transform.position;
            transform.parent = theFuckingTile.transform;

            AttackTarget();
        }
    }

    public void AttackTarget()
    {
        if (target.GetPathChart()[TroopGridsCoord] == new Vector2Int(-1,-1))
        {
            target.gameObject.GetComponent<TroopBehavior>().TakeDamage(EnemyInfo.Damage);
            Destroy(gameObject);
        }
    }
}
