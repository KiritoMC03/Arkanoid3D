using UnityEngine;
using System.Collections;
using System;

namespace Arkanoid.Platform
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class PlatformMotor : MonoBehaviour, IPlatformMotor
    {
        private Rigidbody _rigidbody = null;
        private Vector3 _startPosition = Vector3.zero;

        private void Awake()
        {
            InitFields();
            Debug.LogWarning("It is recommended to install StartPosition if \"IPlatformMotor.SetStartPosition(Vector3 position)\".");
        }

        private void InitFields()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void MoveTo(Vector3 position)
        {
            _rigidbody.MovePosition(position);
        }

        public void MoveToStartPosition()
        {
            MoveTo(_startPosition);
        }

        public void SetStartPosition(Vector3 position)
        {
            _startPosition = position;
        }
    }
}