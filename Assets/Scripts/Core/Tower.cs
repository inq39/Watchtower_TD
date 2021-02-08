using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watchtower.BankSystem;

namespace Watchtower.Core
{
    public class Tower : MonoBehaviour
    {
        [SerializeField]
        private int _buyCost;


        public bool CreateTower(Tower towerPrefab, Vector3 position)
        {
            Bank bank = GameObject.FindWithTag("Bank").GetComponent<Bank>();
            if (bank == null)
            {
                Debug.LogError("Bank is NULL.");
                return false;
            }
            if (_buyCost <= bank.CurrentBalance)
            {
                Instantiate(towerPrefab, position, Quaternion.identity);
                bank.WithDraw(_buyCost);
                return true;
            }
            return false;
        }
    }
}
