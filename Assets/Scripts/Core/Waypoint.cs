using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watchtower.Core
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField]
        private Tower _towerPrefab;
        
        [SerializeField]
        private bool _isPlaceable;
        public bool IsPlaceable { get { return _isPlaceable; } }

        private bool _towerIsPlaced = false;



        private void OnMouseDown()
        {
            if (_isPlaceable)
            {
                _towerIsPlaced = _towerPrefab.CreateTower(_towerPrefab, transform.position);
                _isPlaceable = !_towerIsPlaced;
            }

            
        }
    }
}
