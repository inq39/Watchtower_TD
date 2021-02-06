using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.SceneManagement;
using System;

namespace Watchtower.Core
{
    [ExecuteAlways]
    public class CoordinateText : MonoBehaviour
    {
        private TextMeshPro _coordinateLabel;
        private Vector2Int _coordinate = new Vector2Int();
        private string _coordinateText;
        private Waypoint _waypoint;
        private bool _isLabelEnable = true;
        [SerializeField]
        private Color _isPlacableColor;
        [SerializeField]
        private Color _isNotPlacableColor;
        // Start is called before the first frame update
        void Awake()
        {
            _coordinateLabel = GetComponentInChildren<TextMeshPro>();
            UpdateCoordinateText();
            _waypoint = GetComponentInParent<Waypoint>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Application.isPlaying && PrefabStageUtility.GetPrefabStage(gameObject) == null)
            {
                UpdateCoordinateText();
                UpdateGameObjectText();             
            }
            ToggleCoordinateLabel();
            UpdateCoordinateTextColor();
        }

        private void UpdateCoordinateTextColor()
        {
            _coordinateLabel.color = _waypoint.IsPlaceable ? _isPlacableColor : _isNotPlacableColor;
        }
        private void ToggleCoordinateLabel()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                _isLabelEnable = !_isLabelEnable;
                _coordinateLabel.enabled = _isLabelEnable;
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