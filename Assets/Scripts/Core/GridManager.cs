using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watchtower.Core;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private Vector2Int _gridSize; 
    Dictionary<Vector2Int, Node> _grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        throw new NotImplementedException();
    }
}
