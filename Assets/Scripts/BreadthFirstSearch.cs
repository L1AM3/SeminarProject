using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstSearch : MonoBehaviour
{
    [SerializeField] private Dictionary<Vector2Int, int> distanceChart = new();
    [SerializeField] private Dictionary<Vector2Int, Vector2Int> pathChart = new();

    public Dictionary<Vector2Int, Vector2Int> GetPathChart() => pathChart;

    public void BFS(Vector2Int startPos, GridManager gridManager)
    {
        //Make sure BFS can take place, grid needs to exist, is start position in grid, is tile walkable
        if (gridManager == null) return;
        if (gridManager.GetTileFromDictionary(startPos) == null) return;
        //if (!gridManager.GetTileFromDictionary(startPos).IsWalkable()) return;

        Vector2Int currentPos = startPos;
        Queue<Vector2Int> frontier = new Queue<Vector2Int>();
        Vector2Int[] directions = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };

        //Clears out old data
        distanceChart.Clear();
        pathChart.Clear();

        //Adds current position to the frontier, dc, pc
        frontier.Enqueue(currentPos);
        distanceChart.Add(currentPos, 0);
        pathChart.Add(currentPos, new Vector2Int(-1, -1));

        //goes through each tile in the frontier
        while(frontier.Count > 0)
        {
            currentPos = frontier.Dequeue();

            //checking all four directions of tiles from current position
            foreach (Vector2Int direction in directions)
            {
                if (frontier.Count == 0) ;
                    //Debug.Log(distanceChart[currentPos]);

                //Ensuring tile hasn't already been explored, making sure tile is pathable
                if (distanceChart.ContainsKey(currentPos + direction)) continue;
                if (gridManager.GetTileFromDictionary(currentPos + direction) == null) continue;
                if (!gridManager.GetTileFromDictionary(currentPos + direction).IsWalkable()) continue;

                //Adding a checked tile each time based on current position and direction
                frontier.Enqueue(currentPos + direction);
                distanceChart.Add(currentPos + direction, distanceChart[currentPos] + 1);
                pathChart.Add(currentPos + direction, currentPos);
            }
        }
    }
}
