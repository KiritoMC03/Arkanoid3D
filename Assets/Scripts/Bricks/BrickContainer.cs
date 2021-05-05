using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;
using System;

namespace Arkanoid.Bricks
{
    public class BrickContainer : MonoBehaviour, IBrickContainer
    {
        [SerializeField] private List<GameObject> _bricks = null;

        private void Awake()
        {
            PlayerPrefs.DeleteAll();

            if (_bricks == null || _bricks.Count == 0)
            {
                throw new Exception("Bricks count must not be null.");
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public int GetBrickValue()
        {
            return _bricks.Count;
        }
    }
}