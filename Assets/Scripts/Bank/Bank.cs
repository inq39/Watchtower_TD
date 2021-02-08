using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Watchtower.BankSystem
{
    public class Bank : MonoBehaviour
    {
        private Scene _scene;
        [SerializeField]
        private int _startBalance;
        [SerializeField]
        private int _currentBalance;
        public int CurrentBalance { get { return _currentBalance; } }

        private void Awake()
        {
            _currentBalance = _startBalance;
            _scene = SceneManager.GetActiveScene();
        }

        public void WithDraw(int amount)
        {
            if (amount <= _currentBalance)
            {
                _currentBalance -= Mathf.Abs(amount);
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
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(_scene.buildIndex);
        }
    }
}
