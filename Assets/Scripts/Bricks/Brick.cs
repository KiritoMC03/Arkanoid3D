using Arkanoid.Stats;
using UnityEngine;
using UnityEngine.Events;

namespace Arkanoid.Bricks
{
    public class Brick : MonoBehaviour, IBrick
    {
        public UnityEvent OnBallHitLink { get => OnBallHit; }
        public UnityEvent OnBallHit;

        private void Awake()
        {
            OnBallHit.AddListener(Destroy);
        }

        public void Destroy()
        {
            Score.Increase();
            Destroy(gameObject);
        }
    }
}