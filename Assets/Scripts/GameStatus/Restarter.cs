using UnityEngine;
using System.Collections;
using Arkanoid.Ball;
using System;
using Utils;
using UnityEngine.Events;

namespace Arkanoid.GameStatus
{
    public class Restarter : MonoBehaviour
    {
        [Header("Implement IStarter.")]
        [SerializeField] private GameObject _gameStarter = null;
        private IStarter _starter = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _starter = _gameStarter.GetInterface<IStarter>("Game Starter");
        }

        public void Restart()
        {
            _starter.StartGame();
        }
    }
}