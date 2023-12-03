using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBehavior Enemy;
    public event Action EnemyTurnFinished;
    [SerializeField] private Vector2Int enemySpawnRange;
    [SerializeField] private GridManager grid;
    private List<EnemyBehavior> spawnedEnemies = new();


    private void Start()
    {
        TroopManager.TroopTurnFinished += ManageEnemyBehavior;

    }

    private void OnDisable()
    {
        TroopManager.TroopTurnFinished -= ManageEnemyBehavior;
    }

    private void ManageEnemyBehavior()
    {
        //grid = FindObjectOfType<GridManager>();

        for (int y = 0; y < grid.GetHeight(); y++)
        {
            var gridCoord = new Vector2Int(0, y);

            Tile tile = grid.GetTileFromDictionary(gridCoord);

            if (tile)
            {
                tile.GetComponent<BreadthFirstSearch>().BFS(gridCoord, grid);
            }
        }

        StartCoroutine(Co_SpawnEnemyNoTile());
    }

    private IEnumerator Co_MoveAllEnemies()
    {
        List<EnemyBehavior> enemies = new(spawnedEnemies);

        foreach (var enemy in enemies)
        {
            int enemyMovement = 0;

            if (enemy == null)
            {
                spawnedEnemies.Remove(enemy);
                continue;
            }

            while (enemy != null && enemyMovement < enemy.EnemyInfo.Movement)
            {
                yield return new WaitForSeconds(0.15f);

                if (enemy == null)
                {
                    spawnedEnemies.Remove(enemy);
                    continue;
                }

                enemy.MoveEnemy();
                enemyMovement++;
            }

            yield return new WaitForSeconds(0.30f);
        }

        EnemyTurnFinished?.Invoke();
    }

    public IEnumerator Co_SpawnEnemyNoTile()
    {
        int numEnemies = UnityEngine.Random.Range(enemySpawnRange.x, enemySpawnRange.y);

        for (int i = 0; i < numEnemies; i++)
        {
            yield return new WaitForSeconds(0.33f);
            SpawnEnemy(grid.GetTileFromDictionary(new Vector2Int(grid.GetWidth() - 1, UnityEngine.Random.Range(0, grid.GetHeight()))));
        }

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(Co_MoveAllEnemies());

        //EnemyTurnFinished?.Invoke();
    }

    bool SpawnEnemy(Tile tile)
    {
        if (tile.GetComponentInChildren<EnemyBehavior>() != null) return false;

        EnemyBehavior localEnemy = Instantiate(Enemy, tile.transform.position, Quaternion.identity, tile.transform);
        localEnemy.SetGridCoords(tile.gridCoords);
        localEnemy.SetGrid(grid);

        List<BreadthFirstSearch> interestingTings = localEnemy.GetPossibleTargets();

        if (interestingTings.Count == 0)
        {
            Destroy(localEnemy.gameObject);
            return false;
        }

        localEnemy.SetTarget(interestingTings[UnityEngine.Random.Range(0, interestingTings.Count)]);
        localEnemy.SetRandomDamage();
        spawnedEnemies.Add(localEnemy);

        return true;
    }


}
