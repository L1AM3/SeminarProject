using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public TroopData EnemyInfo;
    private GridManager Grid;
    public Vector2Int TroopGridsCoord;
    private BreadthFirstSearch target;

    public void DebuffHealth(int debuffval)
    {
        if (debuffval >= EnemyInfo.Damage)
        {
            EnemyInfo.Damage = 1;
            return;
        }

        EnemyInfo.Damage -= debuffval;
    }

    public void DebuffDivHealth(int debuffval)
    {
        Debug.Assert(debuffval > 0);
        float newHealth = (float) EnemyInfo.Damage / debuffval;
        EnemyInfo.Damage = (int) Mathf.Ceil(newHealth);
    }

    public bool KillEnemy(int damage)
    {
        if (damage >= EnemyInfo.Damage)
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

        if (theFuckingTile != null && !EnemyOnTile(theFuckingTile))
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

    public bool EnemyOnTile(Tile tile)
    {
        EnemyBehavior otherEnemy = tile.GetComponentInChildren<EnemyBehavior>();

        if (otherEnemy == null) return false;

        return true;
    }
}
