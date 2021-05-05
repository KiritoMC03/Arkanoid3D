using UnityEngine;
using System.Collections;
using ObjectPool;
using System;
using Utils;
using Arkanoid.Platform;
using Arkanoid.GameStatus;

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

        [Header("Implement IVictoryTracker.")]
        [SerializeField] private GameObject _victoryTrackerComponent = null;
        private IVictoryTracker _victoryTracker = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _ball = _ballPrefab.GetInterface<IBall>("Ball Prefab");
            _platform = _platformMotor.GetInterface<IPlatformMotor>("Platform Motor");
            _victoryTracker = _victoryTrackerComponent.GetInterface<IVictoryTracker>("Victory Tracker Component");
        }

        public void Spawn()
        {
            var newBall = ObjectPooler.Instance.GetObject(_ball.Type);
            newBall.transform.position = _startPosition;
            newBall.GetInterface<IBall>("Ball Prefab").ResetRigidbody();
            newBall.GetInterface<IBall>("Ball Prefab").SetVictoryTracker(_victoryTracker);
            _platform.MoveToStartPosition();
        }
    }
}