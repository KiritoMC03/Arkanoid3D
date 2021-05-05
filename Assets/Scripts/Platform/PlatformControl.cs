using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Arkanoid.Platform
{
    public class PlatformControl : MonoBehaviour
    {
        [SerializeField] private float _maxOffset = 4f;

        [Header("Implement IPlatformMotor.")]
        [SerializeField] private GameObject _platformMotor = null;
        private IPlatformMotor _motor = null;

        private Transform _transform = null;
        private Camera _camera = null;
        private Vector3 _startPosition = Vector3.zero;
        private Vector3 _tempPosition = Vector3.zero;

        private void Awake()
        {
            InitFields();
            _startPosition = _transform.position;
        }

        private void InitFields()
        {
            _transform = transform;
            _camera = Camera.main;
            _motor = _platformMotor.GetInterface<IPlatformMotor>("Platform Motor");
        }

        private void OnMouseDrag()
        {
            var target = ConvertMousePositionToWorld();
            var offset = Mathf.Clamp(target.x, -_maxOffset, _maxOffset);
            _motor.MoveTo(CalculatePosition(_startPosition.x + offset));
        }

        private Vector3 ConvertMousePositionToWorld()
        {
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _camera.transform.position.z);
            var point = _camera.ScreenToWorldPoint(mousePosition);
            point.Set(_startPosition.x - point.x, _startPosition.y - point.y, point.z);
            return point;
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