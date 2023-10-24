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

    private void Start()
    {
        TroopManager.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && IsTroopSelected)
        {
            TroopMovement(new Vector2Int(1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && IsTroopSelected)
        {
            TroopMovement(new Vector2Int(0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && IsTroopSelected)
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
            Grid.GetTileFromDictionary(TroopGridsCoord).SetTroop(null);

            TroopGridsCoord += dir;
            transform.position = theFuckingTile.transform.position;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Collider2D>().enabled = true;

            GetComponent<BreadthFirstSearch>().BFS(TroopGridsCoord, Grid);
        }

        TroopManager.Invoke();
    }

    public void TroopStacking()
    {
        troopStackCounter++;
        Debug.Log(troopStackCounter.ToString());
    }

    public TroopType GetTroopType() => troopType;
    public void SetType(TroopType type) => troopType = type;

    public bool TroopAttacking(Tile tile)
    {
        var Enemy = tile.GetComponentInChildren<EnemyBehavior>();

        if (Enemy == null)
            return true;

        if (troopType == TroopType.AdditionArcher)
        {
            Enemy.KillEnemy(TroopInfo.Damage);

            if (Enemy == null)
                return true;

            return false;
        }

        if (troopType == TroopType.SubtractionSwordsman)
        {
            Enemy.DebuffHealth(TroopInfo.Damage);
            return false;
        }
        return false;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(TroopInfo.Health);
        TroopInfo.Health -= damage;
        //Debug.Log(TroopInfo.Health.ToString());

        if (TroopInfo.Health <= 0)
        {
            Debug.Log("Player DeD");
        }
    }
}
