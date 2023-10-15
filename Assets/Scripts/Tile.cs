using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    private bool hasTroop = false; 
    private Vector2 tilePos;
    private GridManager _gridManager;
    public Vector2Int gridCoords;

    public void SetGridManager(GridManager gridManager) => _gridManager = gridManager;
    public GridManager GetGridManager() => _gridManager;
    public void SetGridCords(Vector2Int gridCoordinates) => gridCoords = gridCoordinates;
    public Vector2Int GetGridCords() => gridCoords;
    public void InverthasTroop() => hasTroop = !hasTroop;
    public bool HasTroop() => hasTroop;

    public void Update()
    {
        
    }

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        _gridManager.OnTileSelected(this);
    }
}
