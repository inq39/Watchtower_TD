using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watchtower.Core;

namespace Watchtower.Movement
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMover : MonoBehaviour
    {
       
        private List<Waypoint> _path = new List<Waypoint>();
        [SerializeField] [Range(0f, 5f)]
        private float _speed = 1f;
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            if (_enemy == null)
            {
                Debug.LogError("Enemy is NULL.");
            }
        }

        void OnEnable()
        {
            FindPath();
            ReturnToStart();
            StartCoroutine(FollowPath());
        }

        private void ReturnToStart()
        {
            transform.position = _path[0].transform.position;
        }

        private void FindPath()
        {
            _path.Clear();
            GameObject parent = GameObject.FindGameObjectWithTag("Path");

            foreach (Transform child in parent.transform)
            {
                Waypoint waypoint = child.GetComponent<Waypoint>();

                if (waypoint != null)
                _path.Add(waypoint);
            }
        }

       IEnumerator FollowPath()
        {
            foreach (Waypoint waypoint in _path)
            {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = waypoint.transform.position;
                float distanceTravelled = 0f;

                transform.LookAt(endPosition);

                while (distanceTravelled <= 1.0f)
                {
                    distanceTravelled += Time.deltaTime * _speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, distanceTravelled);
                    yield return new WaitForEndOfFrame();
                }

            }
            FinishPath();
        }

        private void FinishPath()
        {
            _enemy.PenaltyGold();
            gameObject.SetActive(false);
        }
    }
}
