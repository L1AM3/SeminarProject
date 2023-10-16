using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float SpawnDelay;
    private float SpawnTimer;
    [SerializeField] private GridManager grid;
    private bool enemySpawnTile;
    private Tile tile;

    private void Start()
    {
        SpawnTimer = SpawnDelay;
    }

    // Start is called before the first frame update
    void SpawnEnemy(Tile tile)
    {
        Instantiate(Enemy, tile.transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer -= Time.deltaTime; 

        if (SpawnTimer < 0)
        {
            SpawnEnemy(grid.GetTileFromDictionary(new Vector2Int(grid.GetWidth() - 1, Random.Range(0, grid.GetHeight()))));
            SpawnTimer = SpawnDelay;
        }
    }
}
