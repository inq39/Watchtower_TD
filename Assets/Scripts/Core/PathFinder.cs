using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watchtower.Core
{
    public class PathFinder : MonoBehaviour
    {
        [SerializeField]
        private Node _currentSearchNode;
        private Vector2Int[] _exploreDirections = new Vector2Int[] { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
        private GridManager _gridManager;
        private Dictionary<Vector2Int, Node> _grid;

        private void Awake()
        {
            _gridManager = FindObjectOfType<GridManager>();
            if (_gridManager != null)
            {
                _grid = _gridManager.Grid;
            }
        }

        private void Start()
        {
            ExploreNeighbors();
        }

        private void ExploreNeighbors()
        {
            List<Node> neighbors = new List<Node>();

            foreach (var direction in _exploreDirections)
            {
                Vector2Int searchVector = _currentSearchNode._node + direction;
                if (_grid.ContainsKey(searchVector))
                {
                    neighbors.Add(_grid[searchVector]);

                    //remove - only for testing
                    _grid[searchVector]._isExplored = true;
                    _grid[_currentSearchNode._node]._isPath = true;
                }
            }

        }
    }
}
