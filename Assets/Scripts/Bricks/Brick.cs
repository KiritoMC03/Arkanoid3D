using Arkanoid.Stats;
using ObjectPool;
using UnityEngine;
using UnityEngine.Events;

namespace Arkanoid.Bricks
{
    public class Brick : MonoBehaviour, IBrick, IPooledObject
    {
        public UnityEvent OnBallHitLink { get => OnBallHit; }
        public UnityEvent OnBallHit;
        public ObjectPooler.ObjectInfo.ObjectType Type { get => type; }
        [SerializeField] private ObjectPooler.ObjectInfo.ObjectType type = ObjectPooler.ObjectInfo.ObjectType.Brick;

        private void Awake()
        {
            OnBallHit.AddListener(Destroy);
        }

        public void Destroy()
        {
            Score.Instance.Increase();
            BrickCounter.Instance.Decrease(1);
            Destroy(gameObject);
        }
    }
}