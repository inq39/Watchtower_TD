using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watchtower.Core
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemyPrefab;
        [SerializeField]
        private float _spawnTimer;
        [SerializeField]
        private int _poolSize;

        private GameObject[] _enemyPool;

        private void Awake()
        {
            GenerateEnemyPool();
        }

        private void GenerateEnemyPool()
        {
            _enemyPool = new GameObject[_poolSize];

            for (int i = 0; i < _enemyPool.Length; i++)
            {
                _enemyPool[i] = Instantiate(_enemyPrefab, transform);
                _enemyPool[i].SetActive(false);
            }
        }

        private void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        IEnumerator SpawnEnemies()
        {
            while (true)
            {
                EnableEnemyInPool();
                yield return new WaitForSeconds(_spawnTimer);
            }
        }

        private void EnableEnemyInPool()
        {
            foreach (var enemy in _enemyPool)
            {
                if (enemy.activeInHierarchy) continue;
                if (!enemy.activeInHierarchy)
                {
                    enemy.SetActive(true);
                    return;
                }
            }
        }
    }
}
