using Arkanoid.Ball;
using Arkanoid.Bricks;
using Arkanoid.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Arkanoid.GameStatus
{
    public class Starter : MonoBehaviour, IStarter
    {
        public UnityEvent OnStart;

        [Header("Implement IBallSpawner.")]
        [SerializeField] private GameObject _ballSpawner = null;
        private IBallSpawner _spawner = null;

        [Header("Implement IBrickBuilder.")]
        [SerializeField] private GameObject _brickBuilder = null;
        private IBrickBuilder _builder = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _spawner = _ballSpawner.GetInterface<IBallSpawner>("Ball Spawner");
            _builder = _brickBuilder.GetInterface<IBrickBuilder>("Brick Builder");
        }

        public void StartGame()
        {
            Score.Instance.ResetValue();
            _spawner.Spawn();
            _builder.Build();
        }
    }
}