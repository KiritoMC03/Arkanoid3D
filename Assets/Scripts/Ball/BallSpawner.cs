using UnityEngine;
using System.Collections;
using ObjectPool;
using System;
using Utils;

namespace Arkanoid.Ball
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPosition = Vector3.zero;

        [Header("Implement IBall.")]
        [SerializeField] private GameObject _ballPrefab = null;
        private IBall _ball = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _ball = _ballPrefab.GetInterface<IBall>("Ball Prefab");
        }

        public void Spawn()
        {
            var newBall =  ObjectPooler.Instance.GetObject(_ball.Type);
            newBall.transform.position = _startPosition;
            newBall.GetInterface<IBall>("Ball Prefab").ResetRigidbody();
        }
    }
}