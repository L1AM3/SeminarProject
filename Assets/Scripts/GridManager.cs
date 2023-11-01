using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public event Action<Tile> TileSelected;
    private bool enemySpawningTile;

    private int[,] gridLayout =
    {
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, }
    };

    [SerializeField] private List<Tile> TileTypes;

    [SerializeField] private int width, height;

    [SerializeField] private Tile DefaultTile;
    //[SerializeField] private Tile homeTilePrefab;
    //[SerializeField] private Tile enemyTilePrefab;

    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> tiles;

    public int GetWidth() => width;
    public int GetHeight() => height;

    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = x * height + y;
                var gridCoord = new Vector2Int(x, y);
                if (index < gridLayout.Length)
                {
                    tiles[gridCoord] = CreateTile(TileTypes[gridLayout[y, x]], gridCoord);
                }
                else
                {
                    tiles[gridCoord] = CreateTile(DefaultTile, gridCoord);
                }
            }
        }

        for (int y = 0; y < height;y++)
        {
            var gridCoord = new Vector2Int(0, y);

            tiles[gridCoord].GetComponent<BreadthFirstSearch>().BFS(gridCoord, this);
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)-height / 2 + 0.5f, 10);
    }

    public Tile CreateTile(Tile prefabtile, Vector2Int tilepos)
    {
        var spawnedTile = Instantiate(prefabtile, new Vector2(tilepos.x, -tilepos.y), Quaternion.identity, transform);
        spawnedTile.SetGridManager(this);
        spawnedTile.SetGridCords(new Vector2Int(tilepos.x, tilepos.y));
        spawnedTile.name = $"Tile {tilepos.x} {tilepos.y}";

        var isOffset = (tilepos.x + tilepos.y) % 2 == 1;
        spawnedTile.Init(isOffset);

        return spawnedTile;
    }

    public Tile GetTileFromDictionary(Vector2Int coords)
    {
        if(coords.x >= width || coords.y >= height || coords.x < 0 || coords.y < 0) return null;

        return tiles[coords];
    }

    public void OnTileSelected(Tile tile)
    {
        TileSelected?.Invoke(tile);
    }
}
