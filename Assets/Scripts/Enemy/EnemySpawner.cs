using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyBehavior Enemy;
    public float SpawnDelay;
    public event Action EnemyTurnFinished;
    [SerializeField] private GridManager grid;
    private List<EnemyBehavior> spawnedEnemies = new();


    private void Start()
    {
        TroopManager.TroopTurnFinished += ManageEnemyBehavior;
    }

    private void ManageEnemyBehavior()
    {
        for (int y = 0; y < grid.GetHeight(); y++)
        {
            var gridCoord = new Vector2Int(0, y);

            grid.GetTileFromDictionary(gridCoord).GetComponent<BreadthFirstSearch>().BFS(gridCoord, grid);
        }

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
            int enemyMovement = 0;

            if (enemy == null)
            {
                spawnedEnemies.Remove(enemy);
                continue;
            }

            while (enemy != null && enemyMovement < enemy.EnemyInfo.Movement)
            {
                yield return new WaitForSeconds(0.5f);

                if (enemy == null)
                {
                    spawnedEnemies.Remove(enemy);
                    continue;
                }

                enemy.MoveEnemy();
                enemyMovement++;
            }
        }

        EnemyTurnFinished?.Invoke();
    }

    public IEnumerator Co_SpawnEnemyNoTile()
    {
        int numEnemies = UnityEngine.Random.Range(1, 4);

        for (int i = 0; i < numEnemies; i++)
        {
            yield return new WaitForSeconds(0.25f);
            SpawnEnemy(grid.GetTileFromDictionary(new Vector2Int(grid.GetWidth() - 1, UnityEngine.Random.Range(0, grid.GetHeight()))));
        }

        yield return new WaitForSeconds(1f);
        EnemyTurnFinished?.Invoke();
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

        spawnedEnemies.Add(localEnemy);

        return true;
    }


}
