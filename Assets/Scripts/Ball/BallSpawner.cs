using UnityEngine;
using System.Collections;
using ObjectPool;
using System;
using Utils;
using Arkanoid.Platform;

namespace Arkanoid.Ball
{
    public class BallSpawner : MonoBehaviour, IBallSpawner
    {
        [SerializeField] private Vector3 _startPosition = Vector3.zero;

        [Header("Implement IBall.")]
        [SerializeField] private GameObject _ballPrefab = null;
        private IBall _ball = null;

        [Header("Implement IPlatformMotor.")]
        [SerializeField] private GameObject _platformMotor = null;
        private IPlatformMotor _platform = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _ball = _ballPrefab.GetInterface<IBall>("Ball Prefab");
            _platform = _platformMotor.GetInterface<IPlatformMotor>("Platform Motor");
        }

        public void Spawn()
        {
            var newBall = ObjectPooler.Instance.GetObject(_ball.Type);
            newBall.transform.position = _startPosition;
            newBall.GetInterface<IBall>("Ball Prefab").ResetRigidbody();
            _platform.MoveToStartPosition();
        }
    }
}