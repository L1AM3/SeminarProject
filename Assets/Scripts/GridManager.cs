using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public event Action<Tile> TileSelected;

    [SerializeField] private int width, height;

    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Tile homeTilePrefab;
    [SerializeField] private Tile enemyTilePrefab;

    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> tiles;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0)
                {

                    tiles[new Vector2(x, y)] = CreateTile(homeTilePrefab, new Vector2Int(x, y));
                    continue;
                }
                else if (x == width - 1) 
                {
                    tiles[new Vector2(x, y)] = CreateTile(enemyTilePrefab, new Vector2Int(x, y));
                    continue;
                }

                tiles[new Vector2(x, y)] = CreateTile(tilePrefab, new Vector2Int( x, y));
            }
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, 10);
    }

    public Tile CreateTile(Tile prefabtile, Vector2Int tilepos)
    {
        var spawnedTile = Instantiate(prefabtile, new Vector2(tilepos.x, tilepos.y), Quaternion.identity, transform);
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
