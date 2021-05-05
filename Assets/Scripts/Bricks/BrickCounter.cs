using UnityEngine;
using System.Collections;
using Arkanoid.GameStatus;
using System;
using Utils;

namespace Arkanoid.Bricks
{
    public class BrickCounter : MonoBehaviour, IBrickCounter
    {
        [Header("Implement IVictoryTracker.")]
        [SerializeField] private GameObject _victoryTrackerComponent = null;
        private IVictoryTracker _victoryTracker = null;
        public static BrickCounter Instance = null;
        private int _count = 0;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            Instance = this;
            _victoryTracker = _victoryTrackerComponent.GetInterface<IVictoryTracker>("Victory Tracker Component");
        }

        public void Increase(int value)
        {
            _count += value;
        }

        public void Decrease(int value)
        {
            _count -= value;
            Debug.Log("Decrease: " + _count);
            CheckOnZero();
        }

        public int GetCount()
        {
            return _count;
        }

        public void ResetCount()
        {
            _count = 0;
        }

        private void CheckOnZero()
        {
            Debug.Log("Check: " + _count);
            if (_count <= 0)
            {
                _victoryTracker.OnVictoryLink?.Invoke();
            }
        }
    }
}