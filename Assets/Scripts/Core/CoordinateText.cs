using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.SceneManagement;

namespace Watchtower.Core
{
    [ExecuteAlways]
    public class CoordinateText : MonoBehaviour
    {
        private TextMeshPro _coordinateLabel;
        private Vector2Int _coordinate = new Vector2Int();
        private string _coordinateText;
        // Start is called before the first frame update
        void Awake()
        {
            _coordinateLabel = GetComponentInChildren<TextMeshPro>();
            UpdateCoordinateText();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Application.isPlaying && PrefabStageUtility.GetPrefabStage(gameObject) == null)
            {
                UpdateCoordinateText();
                UpdateGameObjectText();
            }       
        }

        private void UpdateCoordinateText()
        {
            _coordinate.x = Mathf.RoundToInt(transform.position.x / UnityEditor.EditorSnapSettings.move.x);
            _coordinate.y = Mathf.RoundToInt(transform.position.z / UnityEditor.EditorSnapSettings.move.z);
            _coordinateText = _coordinate.x + ", " + _coordinate.y;
            _coordinateLabel.text = _coordinateText;
        }

        private void UpdateGameObjectText()
        {
            transform.name = _coordinateText;
        }
    }

}