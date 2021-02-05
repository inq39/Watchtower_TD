using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Watchtower.Movement
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField]
        private List<Waypoint> _path = new List<Waypoint>();
        [SerializeField]
        private float _timeBetweenMoves = 1f;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(FollowPath());
        }

       IEnumerator FollowPath()
        {
            foreach (Waypoint waypoint in _path)
            {
                transform.position = waypoint.transform.position;
                yield return new WaitForSeconds(_timeBetweenMoves);
            }
        }
    }
}
