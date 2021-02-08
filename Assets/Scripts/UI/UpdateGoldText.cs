using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Watchtower.UI
{
    public class UpdateGoldText : MonoBehaviour
    {
        private TextMeshProUGUI _goldText;

        private void Awake()
        {
            _goldText = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateText(int balance)
        {
            _goldText.SetText("Gold: " + balance.ToString());
        }
    }
}
