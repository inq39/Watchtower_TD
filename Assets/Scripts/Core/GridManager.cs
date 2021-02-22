using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watchtower.Core;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private Vector2Int _gridSize;
    [SerializeField]
    private Dictionary<Vector2Int, Node> _grid = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grid { get { return _grid; } }

    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (_grid.ContainsKey(coordinates))
        {
            return _grid[coordinates];
        }
        return null;
    }

    private void CreateGrid()
    {
        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                Vector2Int key = new Vector2Int(x, y);
                Node node = new Node(key, true);
                _grid.Add(key, node);
            }
        }
    }
}
