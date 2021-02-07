using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watchtower.Core;

namespace Watchtower.Combat
{
    public class EnemyTargeting : MonoBehaviour
    {
        private Transform _enemy;
        [SerializeField]
        private Transform _weaponToRotate;
        [SerializeField]
        private float _maxWeaponRange;
        [SerializeField]
        private ParticleSystem _particleSystem;


        void Update()
        {
            FindNearestEnemy();
            AimTarget();

        }

        private void AimTarget()
        {
            if (_enemy == null)
            {
                AttackTarget(false);
                return;
            }
                
            float targetDistance = Vector3.Distance(transform.position, _enemy.transform.position);
            if (targetDistance < _maxWeaponRange)
            {
                _weaponToRotate.LookAt(_enemy);
                AttackTarget(true);
            }
            else
            {
                AttackTarget(false);
            }
        }

        private void FindNearestEnemy()
        {
            Enemy[] enemyList = FindObjectsOfType<Enemy>();

            float nearestDistance = Mathf.Infinity;
            Transform nearestEnemy = null;
            foreach (Enemy enemy in enemyList)
            {              
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                
                if (distance <= _maxWeaponRange && distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = enemy.transform;
                }
            }
            _enemy = nearestEnemy;
        }

        private void AttackTarget(bool isEnabled)
        {
            var em = _particleSystem.emission;
            em.enabled = isEnabled;     
        }
    }
}
