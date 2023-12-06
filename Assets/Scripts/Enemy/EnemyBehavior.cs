using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public TroopData EnemyInfo;
    public Vector2Int enemyDamageRange;
    private GridManager Grid;
    public Vector2Int TroopGridsCoord;
    private BreadthFirstSearch target;

    public void Start()
    {
        if(Random.Range(0,2) == 1)
        {
            EnemyInfo.Damage *= -1;
        }
    }

    public void DebuffDivHealth(int debuffval)
    {
        bool isNegative = EnemyInfo.Damage < 0;

        Debug.Assert(debuffval > 0);
        
        float newHealth = (float)Mathf.Abs(EnemyInfo.Damage) / debuffval;

        EnemyInfo.Damage = (int)Mathf.Ceil(newHealth);

        if (isNegative)
        {
            EnemyInfo.Damage = -EnemyInfo.Damage;
        }

    }

    public bool AlterDamage(int damage)
    {
        EnemyInfo.Damage += damage;

        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(ResetColor());

        if (EnemyInfo.Damage == 0)
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.3f);

        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void SetTarget(BreadthFirstSearch target) => this.target = target;
    public void SetGridCoords(Vector2Int gridCoords) => TroopGridsCoord = gridCoords;
    public void SetGrid(GridManager manager) => Grid = manager;

    public Vector2Int GetMovementDir()
    {
        Vector2Int destination = new();
        Vector2Int moveDir = new();

        if (!target.GetPathChart().ContainsKey(TroopGridsCoord))
        {
            var possibleTargets = GetPossibleTargets();
            
            while (possibleTargets.Count > 0)
            {
                int index = Random.Range(0, possibleTargets.Count);

                if (possibleTargets[index].GetPathChart().ContainsKey(TroopGridsCoord))
                {
                    target = possibleTargets[index];
                    destination = possibleTargets[index].GetPathChart()[TroopGridsCoord];
                    moveDir = destination - TroopGridsCoord;

                    return moveDir;
                }

                possibleTargets.Remove(possibleTargets[index]);
            }
        }

        if(target.GetPathChart().ContainsKey(TroopGridsCoord))
        {
            destination = target.GetPathChart()[TroopGridsCoord];
            moveDir = destination - TroopGridsCoord;
            return moveDir;
        }
        else
        {
            return Vector2Int.zero;
        }
    }

    public bool IsHomeBase(Tile tile)
    {
        return tile.gridCoords.x == 0;
    }

    public void AtHomeBase()
    {
        GameManager.Instance.DamageHomebase(EnemyInfo.Damage);
        Destroy(gameObject);
    }

    public void MoveEnemy()
    {
        if (target == null)
        {
            target = GetPossibleTargets()[Random.Range(0, GetPossibleTargets().Count)];

            //if there are no targets we return out
            if (target == null) return;
        }

        Vector2Int dir = GetMovementDir();
        Tile theFuckingTile = Grid.GetTileFromDictionary(TroopGridsCoord + dir);

        if (theFuckingTile.gridCoords == TroopGridsCoord)
        {
            AttackTarget();
        }

        if (theFuckingTile != null && !EnemyOnTile(theFuckingTile))
        {
            TroopGridsCoord += dir;
            transform.position = theFuckingTile.transform.position;
            transform.parent = theFuckingTile.transform;

            if (IsHomeBase(theFuckingTile)) { AtHomeBase(); }

            AttackTarget();
        }
    }

    public void AttackTarget()
    {
        if (target.GetPathChart().ContainsKey(TroopGridsCoord) && target.GetPathChart()[TroopGridsCoord] == new Vector2Int(-1, -1))
        {
            TroopBehavior troopTarget = target.gameObject.GetComponent<TroopBehavior>();

            if (troopTarget)
            {
                troopTarget.TakeDamage(EnemyInfo.Damage);
            }

            Destroy(gameObject);
        }
    }

    public bool EnemyOnTile(Tile tile)
    {
        EnemyBehavior otherEnemy = tile.GetComponentInChildren<EnemyBehavior>();

        if (otherEnemy == null) return false;

        return true;
    }

    public List<BreadthFirstSearch> GetPossibleTargets()
    {
        List<BreadthFirstSearch> interestingTings = new();

        foreach (TroopBehavior troop in TroopManager.troops)
        {
            if(troop == null) continue;

            interestingTings.Add(troop.GetComponent<BreadthFirstSearch>());
        }

        //Adding all the home bases (x is 0) to the interesting list
        for (int i = 0; i < Grid.GetHeight(); i++)
        {
            interestingTings.Add(Grid.GetTileFromDictionary(new Vector2Int(0, i)).GetComponent<BreadthFirstSearch>());
        }

        return interestingTings;
    }

    public void SetRandomDamage()
    {
        EnemyInfo.Damage = Random.Range(enemyDamageRange.x, enemyDamageRange.y);
    }
}
