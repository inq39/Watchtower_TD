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
        private bool _isLabelEnable = true;
        private Color _isPlacableColor = Color.white;
        private Color _isNotPlacableColor = Color.grey;
        private Color _isExploredColor = Color.yellow;
        private Color _isPathColor = Color.blue;
        private GridManager _gridManager;


        void Awake()
        {
            _gridManager = FindObjectOfType<GridManager>();
            _coordinateLabel = GetComponentInChildren<TextMeshPro>();
            UpdateCoordinateText();
        }

     
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
            if (_gridManager == null) 
            {
                Debug.LogError("GridManager is null.");
                return; 
            }

            Node node = _gridManager.GetNode(_coordinate);
            if (node == null)
            {
                //Debug.LogError("Node is null.");
                return;
            }

            if (!node._isWalkable)
            {
                _coordinateLabel.color = _isNotPlacableColor;
            }
            else if (node._isPath)
            {
                _coordinateLabel.color = _isPathColor;
            }
            else if (node._isExplored)
            {
                _coordinateLabel.color = _isExploredColor;
            }
            else
            {
                _coordinateLabel.color = _isPlacableColor;
            }
        }

        private void ToggleCoordinateLabel()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                _isLabelEnable = !_isLabelEnable;
                _coordinateLabel.enabled = _isLabelEnable;
            }
                
        }

        //Script should be paste in an "Editor"-Folder for Building Process because of EditorSnapSetting
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