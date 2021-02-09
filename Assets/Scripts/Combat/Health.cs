using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watchtower.Core;

namespace Watchtower.Combat
{
    [RequireComponent(typeof(Enemy))]
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int _maxHitPoints;
        
        private int _currentHitPoints;

        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }

        void OnEnable()
        {
            _currentHitPoints = _maxHitPoints;
        }
    

        private void OnParticleCollision(GameObject other)
        {
            _currentHitPoints -= 10;
            if (_currentHitPoints <= 0)
            {
                _enemy.RewardGold();
                gameObject.SetActive(false);
            }
        }
    }
}
