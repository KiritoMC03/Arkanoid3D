using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid.Platform
{
    public class PlatformControl : MonoBehaviour
    {
        private Transform _transform = null;
        private Camera _camera = null;
        private Vector3 _tempPosition = Vector3.zero;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _transform = transform;
            _camera = Camera.main;
        }

        private void OnMouseDrag()
        {
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.transform.position.z);
            var worldPoint = _camera.ScreenToWorldPoint(mousePosition);
            _transform.position = CalculatePosition(-worldPoint.x);
        }

        private Vector3 CalculatePosition(float xAxis)
        {
            _tempPosition.x = xAxis;
            _tempPosition.y = _transform.position.y;
            _tempPosition.z = _transform.position.z;
            return _tempPosition;
        }
    }
}