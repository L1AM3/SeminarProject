using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBehavior Enemy;
    public float SpawnDelay;
    public event Action EnemyTurnFinished;
    private float SpawnTimer;
    [SerializeField] private GridManager grid;
    private bool enemySpawnTile;
    private Tile tile;
    private List<EnemyBehavior> spawnedEnemies = new();

    private void Start()
    {
        TroopManager.TroopTurnFinished += ManageEnemyBehavior;
    }

    private void ManageEnemyBehavior()
    {
        if (UnityEngine.Random.Range(0, spawnedEnemies.Count + 1) == 0)
        {
            StartCoroutine(Co_SpawnEnemyNoTile());
        }
        else
        {
            StartCoroutine(Co_MoveAllEnemies());
        }
    }

    private IEnumerator Co_MoveAllEnemies()
    {
        List<EnemyBehavior> enemies = new(spawnedEnemies);

        foreach (var enemy in enemies)
        {
            if(enemy == null)
            {
                spawnedEnemies.Remove(enemy);
                continue;
            }
            yield return new WaitForSeconds(0.5f);
            enemy.MoveEnemy();
        }

        EnemyTurnFinished?.Invoke();
    }

    public IEnumerator Co_SpawnEnemyNoTile()
    {
        yield return new WaitForSeconds(0.25f);
        SpawnEnemy(grid.GetTileFromDictionary(new Vector2Int(grid.GetWidth() - 1, UnityEngine.Random.Range(0, grid.GetHeight()))));
        yield return new WaitForSeconds(1f);
        EnemyTurnFinished?.Invoke();
    }

    bool SpawnEnemy(Tile tile)
    {
        if (tile.GetComponentInChildren<EnemyBehavior>() != null) return false;

        List<BreadthFirstSearch> interestingTings = new();
        
        foreach(TroopBehavior troop in TroopManager.troops)
        {
            interestingTings.Add(troop.GetComponent<BreadthFirstSearch>());
        }

        if (interestingTings.Count == 0) return false;

        EnemyBehavior localEnemy = Instantiate(Enemy, tile.transform.position, Quaternion.identity, tile.transform);
        localEnemy.SetTarget(interestingTings[UnityEngine.Random.Range(0, interestingTings.Count)]);
        localEnemy.SetGridCoords(tile.gridCoords);
        localEnemy.SetGrid(grid);

        spawnedEnemies.Add(localEnemy);

        return true;
    }
}