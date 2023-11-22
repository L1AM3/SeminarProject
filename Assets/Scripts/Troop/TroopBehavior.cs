using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

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
        if (GetTroopType() == TroopType.SubtractionSwordsman || GetTroopType() == TroopType.AdditionArcher)
        {
            GameManager.Instance.EnemyBaseHealth -= Math.Abs(TroopInfo.Damage);

            if(GameManager.Instance.EnemyBaseHealth < 0)
            {
                //win the game, nerd (kind)
            }
        }
        else if (GetTroopType() == TroopType.DivisionDogFighter)
        {
            GameManager.Instance.EnemyBaseHealth = (int)Mathf.Ceil(GameManager.Instance.EnemyBaseHealth / (float) TroopInfo.Damage);
        }

        Tile parentile = GetComponentInParent<Tile>();
        parentile.SetWalkable(true);

        Debug.Log(GameManager.Instance.EnemyBaseHealth);
        TroopManager.RemoveTroop(this);
        Destroy(gameObject);
    }

    public void TroopMovement(Vector2Int dir)
    {
        if (GameManager.Instance.IsTroopPlacing()) return;

        Tile theFuckingTile = Grid.GetTileFromDictionary(TroopGridsCoord + dir);

        if (theFuckingTile != null)
        {
            if (troopType == TroopType.MultiplicationMarine)
            {
                if (TroopOnTile(theFuckingTile))
                    TroopBuff(theFuckingTile);
            }

            if (troopType == TroopType.DivisionDogFighter)
            {
                if (EnemyOnTile(theFuckingTile))
                {
                    EnemyOnTile(theFuckingTile).DebuffDivHealth(TroopInfo.Damage);
                    GetComponentInParent<Tile>().SetWalkable(true);
                    TroopManager.RemoveTroop(this);
                    Destroy(gameObject);
                }
            }

            if (!theFuckingTile.IsWalkable() || TroopOnTile(theFuckingTile)) return;

            if (TroopAttacking(theFuckingTile))
            {
                GetComponentInParent<Tile>().SetWalkable(true);
                TroopGridsCoord = theFuckingTile.gridCoords;
                transform.position = theFuckingTile.transform.position;

                transform.parent = theFuckingTile.transform;
                theFuckingTile.SetWalkable(false);

                if (IsEnemyBase(theFuckingTile)) { AtEnemyBase(); }

                GetComponent<BreadthFirstSearch>().BFS(TroopGridsCoord, Grid);
            }

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

        if(TroopInfo.Damage > 0)
            TroopInfo.Damage++;
        else
            TroopInfo.Damage--;

    }

    public TroopType GetTroopType() => troopType;
    public void SetType(TroopType type) => troopType = type;

    public bool TroopAttacking(Tile tile)
    {
        var Enemy = tile.GetComponentInChildren<EnemyBehavior>();

        if (Enemy == null)
            return true;


        if (troopType == TroopType.AdditionArcher || troopType == TroopType.SubtractionSwordsman)
        {
            if (Enemy.AlterDamage(TroopInfo.Damage))
            {
                return true;
            }

            GetComponentInParent<Tile>().SetWalkable(true);
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
        GetComponentInParent<Tile>().SetWalkable(true);
        Destroy(gameObject);
        return true;
    }

    public void TakeDamage(int damage)
    {
        bool isNegative = TroopInfo.Damage < 0;

        TroopInfo.Damage = Mathf.Abs(TroopInfo.Damage) - Mathf.Abs(damage);

        if (TroopInfo.Damage <= 0)
        {
            GetComponentInParent<Tile>().SetWalkable(true);
            TroopManager.RemoveTroop(this);
            Destroy(gameObject);
        }

        if (isNegative)
        {
            TroopInfo.Damage *= -1;
        }
    }

    public TroopBehavior TroopOnTile(Tile tile)
    {
        TroopBehavior otherTroop = tile.GetComponentInChildren<TroopBehavior>();

        return otherTroop;
    }

    public EnemyBehavior EnemyOnTile(Tile tile)
    {
        EnemyBehavior enemy = tile.GetComponentInChildren<EnemyBehavior>();

        return enemy;
    }

    public void ScaleDamage(int addedDamage) => TroopInfo.Damage *= addedDamage;
}
