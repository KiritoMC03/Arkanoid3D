using UnityEngine;
using System.Collections;
using Arkanoid.Ball;
using System;
using Utils;

namespace Assets.Scripts.GameStatus
{
    public class Restarter : MonoBehaviour
    {
        [Header("Implement IBallSpawner.")]
        [SerializeField] private GameObject _ballSpawner = null;
        private IBallSpawner _spawner = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _spawner = _ballSpawner.GetInterface<IBallSpawner>("Ball Spawner");
        }

        public void Restart()
        {
            _spawner.Spawn();
        }
    }
}