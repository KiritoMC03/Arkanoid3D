using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Arkanoid.GameStatus
{
    public class LossTracker : MonoBehaviour
    {
        public UnityEvent OnBallFell;
        [SerializeField] private Transform _ball = null;
        [SerializeField] private Transform _platform = null;

        private void Awake()
        {
            Validator.CheckFieldOrException(_ball);
            Validator.CheckFieldOrException(_platform);
        }

        private void Update()
        {
            CheckBallPosition();
        }

        private void CheckBallPosition()
        {
            if(_ball == null)
            {
                return;
            }

            if (_ball.position.y < _platform.position.y)
            {
                OnBallFell?.Invoke();
            }
        }
    }
}