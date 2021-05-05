using UnityEngine;
using Arkanoid.Bricks;
using Utils;
using ObjectPool;
using System;
using Arkanoid.GameStatus;

namespace Arkanoid.Ball
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Ball : MonoBehaviour, IBall, IPooledObject
    {
        private IVictoryTracker _victoryTracker = null;
        public ObjectPooler.ObjectInfo.ObjectType Type { get => type; }
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType type = ObjectPooler.ObjectInfo.ObjectType.Ball;

        private Rigidbody _rigidbody = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            var brick = collision.gameObject.GetComponent<IBrick>();
            if (brick != null)
            {
                brick.OnBallHitLink?.Invoke();
            }
        }

        public void ResetRigidbody()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        public void Destroy()
        {
            ResetRigidbody();
            ObjectPooler.Instance.DestroyObject(gameObject);
        }

        public void SetVictoryTracker(IVictoryTracker victoryTracker)
        {
            _victoryTracker = victoryTracker;
            _victoryTracker.OnVictoryLink.AddListener(Destroy);
        }
    }
}