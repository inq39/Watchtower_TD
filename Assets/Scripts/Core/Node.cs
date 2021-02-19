using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watchtower.Core
{
    public class Node
    {
        public Vector2Int _node;
        public bool _isWalkable;
        public bool _isExplored;
        public Node _neigbhor;

        public Node(Vector2Int node, bool isWalkable)
        {
            this._node = node;
            this._isWalkable = isWalkable;
        }
    }
}
