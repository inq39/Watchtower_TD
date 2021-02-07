using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watchtower.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int _maxHitPoints;
        [SerializeField]
        private int _currentHitPoints;
        // Start is called before the first frame update
        void OnEnable()
        {
            _currentHitPoints = _maxHitPoints;
        }
    

        private void OnParticleCollision(GameObject other)
        {
            _currentHitPoints -= 10;
            if (_currentHitPoints <= 0)
            {
                gameObject.SetActive(false);
                
            }
        }
    }
}
