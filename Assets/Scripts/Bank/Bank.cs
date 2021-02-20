using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Watchtower.UI;

namespace Watchtower.BankSystem
{
    public class Bank : MonoBehaviour
    {
        private int _scene;
        [SerializeField]
        private int _startBalance;
        [SerializeField]
        private int _currentBalance;
        public int CurrentBalance { get { return _currentBalance; } }

        [SerializeField]
        private UpdateGoldText _updateGoldText;

        private void Awake()
        {
            _scene = SceneManager.GetActiveScene().buildIndex;

            if (_updateGoldText == null)
            {
                Debug.LogError("GoldText is NULL.");
            }
        }

        private void Start()
        {
            _currentBalance = _startBalance;
            _updateGoldText.UpdateText(_currentBalance);
        }

        public void WithDraw(int amount)
        {
            if (amount <= _currentBalance)
            {
                _currentBalance -= Mathf.Abs(amount);
                _updateGoldText.UpdateText(_currentBalance);
            }
            else
            {
                Debug.Log("Game Over");
                ReloadScene();       
            }
        }

        public void Deposit(int amount)
        {
            _currentBalance += Mathf.Abs(amount);
            _updateGoldText.UpdateText(_currentBalance);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(_scene);
        }
    }
}
