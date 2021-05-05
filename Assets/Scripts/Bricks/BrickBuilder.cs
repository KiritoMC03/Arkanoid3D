using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Arkanoid.Bricks
{
    public class BrickBuilder : MonoBehaviour, IBrickBuilder
    {
        [Header("Implement IBrickCounter.")]
        [SerializeField] private GameObject _brickCounter = null;
        private IBrickCounter _counter = null;
        [SerializeField] private Vector3 _position = Vector3.zero;
        [SerializeField] private GameObject _brickContainer = null;

        private List<IBrickContainer> _brickContainers = null;

        private void Awake()
        {
            InitFields();
        }

        private void InitFields()
        {
            _counter = _brickCounter.GetInterface<IBrickCounter>("Brick Counter");
            _brickContainers = new List<IBrickContainer>();
        }

        public void Build()
        {
            DestroyContainers();
            _counter.ResetCount();
            var newBrickContainer = Instantiate(_brickContainer, _position, Quaternion.identity).GetInterface<IBrickContainer>();
            Debug.Log("Build: " + newBrickContainer.GetBrickValue());
            _counter.Increase(newBrickContainer.GetBrickValue());
            _brickContainers.Add(newBrickContainer);
        }

        public void DestroyContainers()
        {
            for (int i = 0; i < _brickContainers.Count; i++)
            {
                if (_brickContainers[i] != null && !_brickContainers[i].Equals(null))
                {
                    _brickContainers[i]?.Destroy();
                }
            }
        }
    }
}