using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopBehavior : MonoBehaviour
{
    [HideInInspector] public TroopPlacement Placement;
    [HideInInspector] public GridManager Grid;
    public TroopScriptableObject TroopInfo;
    [HideInInspector] public Vector2Int TroopGridsCoord;
    [HideInInspector] public bool IsTroopSelected = false;
    [SerializeField] private int troopStackCounter;
    private TroopType troopType = TroopType.None;
    private int currentMoveCount = 0;
    private bool isCurrentTurn = false;

    private void Start()
    {
        TroopManager.InvokeTroopSpawned(this);
        GetComponent<BreadthFirstSearch>().BFS(TroopGridsCoord, Grid);

        Placement.GetComponent<EnemySpawner>().EnemyTurnFinished += ChangeTurn;
    }

    private void ChangeTurn()
    {
        isCurrentTurn = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && IsTroopSelected && isCurrentTurn)
        {
            TroopMovement(new Vector2Int(1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && IsTroopSelected && isCurrentTurn)
        {
            TroopMovement(new Vector2Int(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && IsTroopSelected && isCurrentTurn)
        {
            TroopMovement(new Vector2Int(0, 1));
        }
    }

    private void OnMouseDown()
    {
        Placement.SelectTroop(this);
    }

    public void TroopMovement(Vector2Int dir)
    {

        Tile theFuckingTile = Grid.GetTileFromDictionary(TroopGridsCoord + dir);

        if (theFuckingTile != null && TroopAttacking(theFuckingTile))
        {
            TroopGridsCoord += dir;
            transform.position = theFuckingTile.transform.position;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Collider2D>().enabled = true;

            GetComponent<BreadthFirstSearch>().BFS(TroopGridsCoord, Grid);

            transform.parent = theFuckingTile.transform;
            currentMoveCount++;

            if(currentMoveCount >= TroopInfo.Movement)
            {
                isCurrentTurn = false;
                TroopManager.InvokeTroopTurnFinished();
                currentMoveCount = 0;
            }
        }
    }

    public void TroopStacking()
    {
        troopStackCounter++;
        TroopInfo.Damage++;
        Debug.Log(troopStackCounter.ToString());
    }

    public TroopType GetTroopType() => troopType;
    public void SetType(TroopType type) => troopType = type;

    public bool TroopAttacking(Tile tile)
    {
        if (troopType == TroopType.MultiplicationMarine)
        {

            return !TroopBuff(tile); ;
        }

        var Enemy = tile.GetComponentInChildren<EnemyBehavior>();

        if (Enemy == null)
            return true;


        if (troopType == TroopType.AdditionArcher)
        {
            if (Enemy.KillEnemy(TroopInfo.Damage))
                return true;

            return false;
        }

        if (troopType == TroopType.SubtractionSwordsman)
        {
            Enemy.DebuffHealth(TroopInfo.Damage);
            TroopManager.RemoveTroop(this);
            Destroy(gameObject);
            return false;
        }

        if (troopType == TroopType.DivisionDogFighter)
        {
            Enemy.DebuffDivHealth(TroopInfo.Damage);
            TroopManager.RemoveTroop(this);
            Destroy(gameObject);
            return false;
        }

        return false;
    }

    private bool TroopBuff(Tile tile)
    {
        TroopBehavior otherTroop = tile.GetComponentInChildren<TroopBehavior>();

        if(otherTroop == null) return false;

        otherTroop.ScaleDamage(TroopInfo.Damage);

        TroopManager.RemoveTroop(this);
        Destroy(gameObject);
        return true;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(TroopInfo.Health);
        TroopInfo.Health -= damage;
        //Debug.Log(TroopInfo.Health.ToString());

        if (TroopInfo.Health <= 0)
        {
            TroopManager.RemoveTroop(this);
            Destroy(gameObject);
        }
    }

    public void ScaleDamage(int addedDamage) => TroopInfo.Damage *= addedDamage;
}
