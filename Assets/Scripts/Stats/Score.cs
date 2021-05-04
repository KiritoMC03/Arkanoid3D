using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Utils;
using UnityEngine.Events;

namespace Arkanoid.Stats
{
    public class Score : MonoBehaviour
    {
        public UnityEvent OnIncrease;
        public static Score Instance = null;
        [SerializeField] private Text _counter = null;
        private static uint _value = 0;

        private void Awake()
        {
            Instance = this;
            Validator.CheckFieldOrException(_counter);
        }

        private void Start()
        {
            OnIncrease.AddListener(SetCounterText);
        }

        public void Increase()
        {
            _value++;
            OnIncrease?.Invoke();
        }

        public void SetCounterText()
        {
            _counter.text = _value.ToString();
        }
    }
}