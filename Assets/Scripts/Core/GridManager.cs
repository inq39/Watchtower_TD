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
    Dictionary<Vector2Int, Node> _grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        CreateGrid();
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
                Debug.Log(_grid[key]._node + " = " + _grid[key]._isWalkable);
            }
        }
    }
}
