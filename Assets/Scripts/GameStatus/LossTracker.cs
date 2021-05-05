using Arkanoid.Ball;
using System;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Arkanoid.GameStatus
{
    [RequireComponent(typeof(Collider))]
    public class LossTracker : MonoBehaviour
    {
        public UnityEvent OnBallFell;
        private Collider _collider = null;

        private void Awake()
        {
            InitFields();
            _collider.isTrigger = true;
        }

        private void InitFields()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var ball = other.gameObject.GetComponent<IBall>();
            if (ball != null)
            {
                ball.Destroy();
                OnBallFell?.Invoke();
            }
        }
    }
}