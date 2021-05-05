using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Utils;
using UnityEngine.Events;
using Arkanoid.DataWork;
using System;

namespace Arkanoid.Stats
{
    public class Score : MonoBehaviour, IScore
    {
        public UnityEvent OnChangeLink { get => OnChange; }
        public UnityEvent OnChange;
        public UnityEvent OnMaxChangeLink { get => OnMaxChange; }
        public UnityEvent OnMaxChange;

        public static Score Instance = null;
        [Header("Implement ISaveLoad.")]
        [SerializeField] private GameObject _saveLoad = null;
        private ISaveLoad _saveLoadComp = null;
        [SerializeField] private Text _mainCounter = null;
        [SerializeField] private Text[] _textCounters = null;
        [SerializeField] private string _scoreText = "Счет: ";
        private static uint _value = 0;
        private const string SAVElOAD_KEY = "Score";

        private void Awake()
        {
            InitFields();
            Validator.CheckFieldOrException(_textCounters);
        }

        private void InitFields()
        {
            Instance = this;
            _saveLoadComp = _saveLoad.GetInterface<ISaveLoad>("Save Load");
        }
        
        private void Start()
        {
            OnChange.AddListener(Save);
            OnChange.AddListener(SetCountersText);
        }

        public void Increase()
        {
            ++_value;
            OnChange?.Invoke();
        }

        public void ResetValue()
        {
            _value = 0;
            OnChange?.Invoke();
        }

        public void SetCountersText()
        {
            _mainCounter.text = _value.ToString();
            for (int i = 0; i < _textCounters.Length; i++)
            {
                _textCounters[i].text = _scoreText + _value.ToString();
            }
        }

        public int GetMaxValue()
        {
            if (_saveLoadComp == null)
            {
                InitFields();
            }

            if (PlayerPrefs.HasKey(SAVElOAD_KEY))
            {
                return _saveLoadComp.LoadInt(SAVElOAD_KEY);
            }
            return 0;
        }

        public void Save()
        {
            if (!PlayerPrefs.HasKey(SAVElOAD_KEY))
            {
                _saveLoadComp.Save(SAVElOAD_KEY, (int)_value);
                OnMaxChange?.Invoke();
            }

            if (_value > _saveLoadComp.LoadInt(SAVElOAD_KEY))
            {
                _saveLoadComp.Save(SAVElOAD_KEY, (int)_value);
                OnMaxChange?.Invoke();
            }
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}