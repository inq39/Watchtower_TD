using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watchtower.BankSystem;

namespace Watchtower.Core
{
    public class Enemy : MonoBehaviour
    {
        private Bank _bank;
        [SerializeField]
        private int _goldReward;
        [SerializeField]
        private int _goldPenalty;
        // Start is called before the first frame update
        
        void Start()
        {
            _bank = GameObject.FindWithTag("Bank").GetComponent<Bank>();
            if (_bank == null)
            {
                Debug.LogError("Bank is NULL.");
            }
        }

        public void RewardGold()
        {
            _bank.Deposit(_goldReward);
        }

        public void PenaltyGold()
        {
            _bank.WithDraw(_goldPenalty);
        }
    }
}
