using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopBehavior : MonoBehaviour
{
    [HideInInspector] public TroopPlacement Placement;
    [HideInInspector] public GridManager Grid;
    public TroopData TroopInfo;
    [HideInInspector] public Vector2Int TroopGridsCoord;
    [HideInInspector] public bool IsTroopSelected = false;
    [SerializeField] private int troopStackCounter;
    private TroopType troopType = TroopType.None;
    [HideInInspector] public int currentMoveCount = 0;
    private bool isCurrentTurn = true;

    private void Start()
    {
        TroopManager.InvokeTroopSpawned(this);
        GetComponent<BreadthFirstSearch>().BFS(TroopGridsCoord, Grid);

        Placement.GetComponent<EnemySpawner>().EnemyTurnFinished += SetCurrentTurnTrue;
        TroopManager.TroopTurnFinished += SetCurrentTurnFalse;
        Grid.TileSelected += CanMoveTroop;
    }

    private void SetCurrentTurnTrue()
    {
        currentMoveCount = 0;
        isCurrentTurn = true;
    }

    private void SetCurrentTurnFalse()
    {
        isCurrentTurn = false;
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

    public void CanMoveTroop(Tile tile)
    {
        if(tile.gridCoords == TroopGridsCoord)
        {
            TroopManager.SetSelectedTroop(this);
        }
    }

    public bool IsEnemyBase(Tile tile)
    {
        return tile.gridCoords.x == Grid.GetWidth() - 1;
    }

    //Yo handeling when dudes get to enemy base
    public void AtEnemyBase()
    {
        if (GetTroopType() == TroopType.AdditionArcher && TroopInfo.Damage >= GameManager.Instance.EnemyBaseHealth)
        {
            //Add win yippe
        }
        else if (GetTroopType() == TroopType.SubtractionSwordsman)
        {
            GameManager.Instance.EnemyBaseHealth -= TroopInfo.Damage;

            if (GameManager.Instance.EnemyBaseHealth < 1)
            {
                GameManager.Instance.EnemyBaseHealth = 1;
            }
        }
        else if (GetTroopType() == TroopType.DivisionDogFighter)
        {
            GameManager.Instance.EnemyBaseHealth = (int)Mathf.Ceil(GameManager.Instance.EnemyBaseHealth / (float) TroopInfo.Damage);
        }

        Debug.Log(GameManager.Instance.EnemyBaseHealth);
        TroopManager.troops.Remove(this);
        Destroy(gameObject);
    }

    public void TroopMovement(Vector2Int dir)
    {
        if (GameManager.Instance.IsTroopPlacing()) return;

        Tile theFuckingTile = Grid.GetTileFromDictionary(TroopGridsCoord + dir);

        if (theFuckingTile != null && TroopAttacking(theFuckingTile) && !TroopOnTile(theFuckingTile))
        {
            TroopGridsCoord = theFuckingTile.gridCoords;
            transform.position = theFuckingTile.transform.position;

            if (IsEnemyBase(theFuckingTile)) { AtEnemyBase(); }

            theFuckingTile.SetWalkable(false);
            GetComponent<BreadthFirstSearch>().BFS(TroopGridsCoord, Grid);

            transform.parent = theFuckingTile.transform;
            currentMoveCount++;

            if (currentMoveCount >= TroopInfo.Movement)
            { 
                isCurrentTurn = false;
            }
        }
    }

    public void TroopStacking()
    {
        troopStackCounter++;
        TroopInfo.Damage++;
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
        //Debug.Log(TroopInfo.Health);
        TroopInfo.Damage -= damage;
        //Debug.Log(TroopInfo.Health.ToString());

        if (TroopInfo.Damage <= 0)
        {
            TroopManager.RemoveTroop(this);
            Destroy(gameObject);
        }
    }

    public bool TroopOnTile(Tile tile)
    {
        TroopBehavior otherTroop = tile.GetComponentInChildren<TroopBehavior>();

        if (otherTroop == null) return false;

        return true;
    }

    public void ScaleDamage(int addedDamage) => TroopInfo.Damage *= addedDamage;
}
