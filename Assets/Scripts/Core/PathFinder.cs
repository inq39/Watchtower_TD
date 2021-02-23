using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watchtower.Core
{
    public class PathFinder : MonoBehaviour
    {
        [SerializeField]
        private Vector2Int _startCoordinate;
        [SerializeField]
        private Vector2Int _destinationCoordinate;

        private Node _startNode;
        private Node _destinationNode;
        private Node _currentSearchNode;
        private Vector2Int[] _exploreDirections = new Vector2Int[] { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
        private GridManager _gridManager;

        private Dictionary<Vector2Int, Node> _grid = new Dictionary<Vector2Int, Node>();
        private Dictionary<Vector2Int, Node> _reached = new Dictionary<Vector2Int, Node>();
        private Queue<Node> _frontier = new Queue<Node>();

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
            _startNode = _gridManager.Grid[_startCoordinate];
            _destinationNode = _gridManager.Grid[_destinationCoordinate];

            Searching();
            BuildPath();
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
                }
            }

            foreach (Node neighbor in neighbors)
            {
                if (!_reached.ContainsKey(neighbor._node) && neighbor._isWalkable)
                {
                    neighbor._connectedTo = _currentSearchNode;
                    _reached.Add(neighbor._node, neighbor);
                    _frontier.Enqueue(neighbor);
                }
            }

        }

        private void Searching()
        {
            bool isRunning = true;

            _frontier.Enqueue(_startNode);
            _reached.Add(_startCoordinate, _startNode);

            while(_frontier.Count > 0 && isRunning)
            {
                _currentSearchNode = _frontier.Dequeue();
                _currentSearchNode._isExplored = true;
                ExploreNeighbors();
                if (_currentSearchNode._node == _destinationCoordinate)
                {
                    isRunning = false;
                }
            }
        }

        private List<Node> BuildPath()
        {
            List<Node> path = new List<Node>();
            Node currentNode = _destinationNode;
            path.Add(currentNode);
            currentNode._isPath = true;

            while (currentNode._connectedTo != null)
            {
                currentNode = currentNode._connectedTo;
                path.Add(currentNode);
                currentNode._isPath = true;
            }
            path.Reverse();
            return path;
        }
    }
}
