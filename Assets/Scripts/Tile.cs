using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    private Vector2 tilePos;
    private GridManager _gridManager;
    public Vector2 gridCoords;

    public void SetGridManager(GridManager gridManager) => _gridManager = gridManager;
    public GridManager GetGridManager() => _gridManager;
    public void SetGridCords(Vector2 gridCoordinates) => gridCoords = gridCoordinates;
    public Vector2 GetGridCords() => gridCoords;

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseEnter()
    {
        highlight.SetActive(true);
        Debug.Log(GetGridCords());
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
