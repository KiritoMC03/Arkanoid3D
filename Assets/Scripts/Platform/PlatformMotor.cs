using UnityEngine;
using System.Collections;
using System;

namespace Arkanoid.Platform
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class PlatformMotor : MonoBehaviour, IPlatformMotor
    {
        private Rigidbody _rigidbody = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void MoveTo(Vector3 position)
        {
            _rigidbody.MovePosition(position);
        }
    }
}