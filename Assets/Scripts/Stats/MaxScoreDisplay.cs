using UnityEngine;
using System.Collections;
using System;
using Utils;
using UnityEngine.UI;

namespace Arkanoid.Stats
{
    public class MaxScoreDisplay : MonoBehaviour
    {
        [SerializeField] private Text[] _maxScore = null;
        [SerializeField] private string _maxScoreText = "Максимальный счет: ";
        [Header("Implement IScore.")]
        [SerializeField] private GameObject _scoreComponent = null;
        private IScore _score = null;
        private uint _value = 0;

        private void Awake()
        {
            InitFields();
            Validator.CheckFieldOrException(_maxScore);
        }

        private void Start()
        {
            Set();
            _score.OnMaxChangeLink.AddListener(Set);
        }

        private void InitFields()
        {
            _score = _scoreComponent.GetInterface<IScore>("Score Component");
        }

        private void OnEnable()
        {
            if (_score != null)
            {
                Set();
                _score.OnMaxChangeLink.RemoveAllListeners();
                _score.OnMaxChangeLink.AddListener(Set);
            }
        }

        private void Set()
        {
            for (int i = 0; i < _maxScore.Length; i++)
            {
                _maxScore[i].text = _maxScoreText + _score.GetMaxValue().ToString();
            }
        }
    }
}