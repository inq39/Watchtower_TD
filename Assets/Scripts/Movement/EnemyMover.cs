using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watchtower.Core;

namespace Watchtower.Movement
{
    public class EnemyMover : MonoBehaviour
    {
       
        private List<Waypoint> _path = new List<Waypoint>();
        [SerializeField] [Range(0f, 5f)]
        private float _speed = 1f;

        // Start is called before the first frame update
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
            GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

            foreach (var waypoint in waypoints)
            {
                _path.Add(waypoint.GetComponent<Waypoint>());
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
            gameObject.SetActive(false);
        }
    }
}
