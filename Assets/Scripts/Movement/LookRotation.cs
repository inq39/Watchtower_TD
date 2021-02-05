using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    private Transform _enemy;
    [SerializeField]
    private Transform _weaponToRotate;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _weaponToRotate.LookAt(_enemy);
    }
}
